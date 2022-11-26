using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class HardDiscCapacityController : Controller
    {
        private readonly IHardDiscCapacityService _hardDiscCapacityService;
        public HardDiscCapacityController(IHardDiscCapacityService hardDiscCapacityService)
        {
            _hardDiscCapacityService = hardDiscCapacityService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]
        public IActionResult Index(int page = 1)
        {
            return View(_hardDiscCapacityService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HardDiscCapacityPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _hardDiscCapacityService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _hardDiscCapacityService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            HardDiscCapacityPostDto postDto = await _hardDiscCapacityService.GetByIdAsync(id);
            return View(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HardDiscCapacityPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _hardDiscCapacityService.UpdateAsync(id, postDto);
            return RedirectToAction("Index");
        }
    }
}
