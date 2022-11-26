using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class SSDController : Controller
    {
        private readonly ISSDService _ssdService;
        public SSDController(ISSDService ssdService)
        {
            _ssdService = ssdService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_ssdService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public IActionResult Create()
        {
            ViewBag.CapacitySSD = _ssdService.GetCapacitiesForSSD();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SSD postDto)
        {
            ViewBag.CapacitySSD = _ssdService.GetCapacitiesForSSD();

            if (!ModelState.IsValid)
            {
                return View();
            }

            var processorPostDto = await _ssdService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CapacitySSD = _ssdService.GetCapacitiesForSSD();
            SSD postDTO = await _ssdService.GetByIdAsync(id);
            return View(postDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, SSD postDTO)
        {
            ViewBag.CapacitySSD = _ssdService.GetCapacitiesForSSD();

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _ssdService.UpdateAsync(id, postDTO);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public async Task<IActionResult> Delete(int id)
        {
            await _ssdService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public async Task<IActionResult> Restore(int id)
        {
            await _ssdService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
