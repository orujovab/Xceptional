using IComp.Service.DTOs.MemoryDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class MemoryController : Controller
    {
        private readonly IMemoryService _memoryService;
        public MemoryController(IMemoryService memoryService)
        {
            _memoryService = memoryService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_memoryService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public IActionResult Create()
        {
            ViewBag.Capacities = _memoryService.GetCapacities();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MemoryPostDto postDto)
        {
            ViewBag.Capacities = _memoryService.GetCapacities();
            if (!ModelState.IsValid)
            {
                return View();
            }

            var processorPostDto = await _memoryService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Capacities = _memoryService.GetCapacities();

            MemoryPostDto postDTO = await _memoryService.GetByIdAsync(id);
            return View(postDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, MemoryPostDto postDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _memoryService.UpdateAsync(id, postDTO);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _memoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Restore(int id)
        {
            await _memoryService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
