using IComp.Core.Entities;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;


        public OrderController(IProductService productService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }

        public async Task<IActionResult> BasketCheckOut()
        {
            try
            {
                var checkout = await _productService.CheckOut();

                return View(checkout);
            }
            catch (ItemNotFoundException)
            {
                TempData["Warning"] = "Səbətdə məhsul tapılmadı";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketOrder(Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var checkout = await _productService.CheckOut();
                    checkout.Order = order;
                    return View("BasketCheckout", checkout);
                }
                await _productService.CreateOrder(order);
                TempData["Success"] = "Mailinizə izləmə kodu göndərildi. Kodu izləmə böməsinə yazıb sifarişinizə baxa bilərsiniz";
                return RedirectToAction("Index", "Home");
            }
            catch (ItemNotFoundException)
            {
                TempData["Warning"] = "Məhsul Tapılmadı";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> CheckOut(int id)
        {
            var viewModel = await _productService.FastOrder(id);

            if (viewModel.Product is null)
            {
                throw new ItemNotFoundException("Bu məhsul stokda yoxdur");
            }

            return PartialView("_FastOrderPartial", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFastOrder(int productid, Order order, int prodcount, int ordercount)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                TempData["Warning"] = message;
                return RedirectToAction("Index", "Home");
            }

            await _productService.CreateOrder(productid, order, prodcount, ordercount);
            TempData["Success"] = "Mailinizə izləmə kodu göndərildi. Kodu izləmə böməsinə yazıb sifarişinizə baxa bilərsiniz";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult TrackOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TrackOrder(string trackid)
        {
            
            try
            {
                var order = await _productService.GetOrderByIdAsync(trackid);
                if (order == null)
                {
                    throw new ItemNotFoundException("Məhsul tapılmadı");
                }
                return RedirectToAction("GetOrderByTrackId", order);
            }
            catch (ItemNotFoundException)
            {
                TempData["Warning"] = "Məhsul tapılmadı";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult GetOrderByTrackId(Order order)
        {
            return View(order);
        }

        public async Task<IActionResult> AddOrderBasket(int id)
        {
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
                string cookie = HttpContext.Request.Cookies["basket"];
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
                    throw new ItemNotFoundException("Stokda sadəcə " + product.Count + " məhsul var");

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


                return PartialView("_OrderBasketPartial", await _productService._getBasket(cookieItems));
            }
            else
            {
                var basketItem = await _productService.UserBasket(id, appUser);


                return PartialView("_OrderBasketPartial", await _productService._getBasket(basketItem));
            }
        }

        public async Task<IActionResult> DeleteOrderBasket(int id)
        {
            return PartialView("_OrderBasketPartial", await _productService.DeleteBasket(id));
        }
    }
}
