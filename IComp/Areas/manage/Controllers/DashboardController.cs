using IComp.Areas.ViewModels;
using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor, Reader")]

    public class DashboardController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IOrderService orderService, IProductService productService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _productService = productService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var totalProfit = await _orderService.GetTotalProfit();

            var orders = await _orderService.GetAllOrder();

            var totalSales = await _orderService.GetTotalSales();

            var categories = _productService.GetCategories();

            var customers = _userManager.Users.Where(x => !x.IsAdmin);

            DashboardViewModel viewModel = new DashboardViewModel
            {
                TotalProfit = totalProfit,
                NewCostumer = customers.Count(),
                OrderCount = orders.Count(),
                TotalSales = totalSales,
                AcceptedOrders = orders.Where(x => (int)x.Status == 2).Count(),
                CanceledOrders = orders.Where(x => (int)x.Status == 4).Count(),
                PendingOrders = orders.Where(x => (int)x.Status == 1).Count(),
                RejectedOrders = orders.Where(x => (int)x.Status == 3).Count(),
                Orders = orders,
                Categories = categories,
            };
            
            return View(viewModel);
        }
    }
}
