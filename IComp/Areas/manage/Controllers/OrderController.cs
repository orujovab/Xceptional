using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public async Task<IActionResult> Index(int page = 1)
        {
            return View( await _orderService.GetAll(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _orderService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            await _orderService.UpdateAsync(order);
            return RedirectToAction("Index");
        }
    }
}
