using IComp.Core.Entities;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class DetailController : Controller
    {
        private IProductService _productService;
        public DetailController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int id)
        {
            DetailViewModel products = new DetailViewModel();

            try
            {
                products = await _productService.FindByIdAsync(id);
                products.Settings = _productService.GetSettings();
            }
            catch (ItemNotFoundException)
            {
                return PartialView("_Error");
            }

            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Comment(int productid, ProductComment comment)
        {
            try
            {
                var Id = await _productService.Comment(comment);
                return RedirectToAction("index", new { id = Id });

            }
            catch (System.Exception)
            {
                TempData["Warning"] = "Short message";
                return RedirectToAction("index", new {id = productid});
            }
        }
    }
}
