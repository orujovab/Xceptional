using IComp.Core.Entities;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IProductService productService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }
        public IActionResult Index(int page = 1)
        {
            HomeViewModel viewModel = null;

            var products = _productService.GetAllProdWithFilter(page);
            
            var brands = _productService.GetBrands();
            brands = brands.Where(x => x.IsPopular).ToList();
            var settings = _productService.GetSettings();
            var categories = _productService.GetCategories();
            var popularCategories = categories.Where(x => x.IsPopular).ToList();
            var sliders = _productService.GetSlider();

            viewModel = new HomeViewModel
            {
                Paginated = products,
                Brands = brands,
                Settings = settings,
                Categories = categories,
                Sliders = sliders,
                PopularCategories = popularCategories,
            };

            return View(viewModel);
        }

        public IActionResult Make()
        {
            var categories = _productService.GetCategories();

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Make(List<int> productsId)
        {
            CommonBasketViewModel viewModel = new CommonBasketViewModel();

            string cookie = HttpContext.Request.Cookies["basket"];
            foreach (var id in productsId)
            {
                if (id == 0)
                {
                    continue;
                }

                if (!await _productService.AnyProd(id))
                {
                    throw new ItemNotFoundException("item not found");
                }

                AppUser appUser = null;

                if (User.Identity.IsAuthenticated)
                {
                    appUser = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
                }

                if (appUser == null)
                {
                    List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

                    if (!string.IsNullOrWhiteSpace(cookie))
                    {
                        cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookie);
                    }

                    BasketCookieItemViewModel cookieItem = cookieItems.FirstOrDefault(x => x.ProductId == id);
                    var product = await _productService.GetByIdAsync(id);

                    if (product == null)
                    {
                        throw new ItemNotFoundException("Item not found");
                    }
                    if (product.Count <= cookieItem?.Count)
                    {
                        throw new ItemNotFoundException("There are only " + product.Count + " products in stock");
                    }

                    if (cookieItem == null)
                    {
                        cookieItem = new BasketCookieItemViewModel { ProductId = id, Count = 1 };
                        cookieItems.Add(cookieItem);
                    }
                    else
                    {
                        cookieItem.Count++;
                    }

                    cookie = JsonConvert.SerializeObject(cookieItems);
                    HttpContext.Response.Cookies.Append("basket", cookie);
                    viewModel = await _productService._getBasket(cookieItems);
                }
                else
                {
                    var basketItem = await _productService.UserBasket(id, appUser);

                    viewModel = await _productService._getBasket(basketItem);
                }
            }


            return RedirectToAction("basketcheckout", "order");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
