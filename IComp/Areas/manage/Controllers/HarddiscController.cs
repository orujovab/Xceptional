using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class HarddiscController : Controller
    {
        private readonly IHardDiscService _hardDiscService;
        public HarddiscController(IHardDiscService hardDiscService)
        {
            _hardDiscService = hardDiscService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_hardDiscService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public IActionResult Create()
        {
            ViewBag.CapacityHDD = _hardDiscService.GetCapacitiesForHDD();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HardDiscPostDto postDto)
        {
            ViewBag.CapacityHDD = _hardDiscService.GetCapacitiesForHDD();

            if (!ModelState.IsValid)
            {
                return View();
            }

            var processorPostDto = await _hardDiscService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CapacityHDD = _hardDiscService.GetCapacitiesForHDD();
            HardDiscPostDto postDTO = await _hardDiscService.GetByIdAsync(id);
            return View(postDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, HardDiscPostDto postDTO)
        {
            ViewBag.CapacityHDD = _hardDiscService.GetCapacitiesForHDD();

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _hardDiscService.UpdateAsync(id, postDTO);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _hardDiscService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Restore(int id)
        {
            await _hardDiscService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
