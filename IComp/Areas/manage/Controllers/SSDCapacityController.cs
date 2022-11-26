using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class SSDCapacityController : Controller
    {
        private readonly ISSDCapacityService _ssdCapacityService;
        public SSDCapacityController(ISSDCapacityService ssdCapacityService)
        {
            _ssdCapacityService = ssdCapacityService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]
        public IActionResult Index(int page = 1)
        {
            return View(_ssdCapacityService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SSDCapacity postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _ssdCapacityService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ssdCapacityService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]
        public async Task<IActionResult> Edit(int id)
        {
            SSDCapacity postDto = await _ssdCapacityService.GetByIdAsync(id);
            return View(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SSDCapacity postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _ssdCapacityService.UpdateAsync(id, postDto);
            return RedirectToAction("Index");
        }
    }
}
