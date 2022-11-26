using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProcessorController : Controller
    {
        private readonly IProcessorService _processorService;
        public ProcessorController(IProcessorService processorService)
        {
            _processorService = processorService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_processorService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public IActionResult Create()
        {
            ViewBag.ProcSeries = _processorService.GetProcSeries();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProcessorPostDTO postDTO)
        {
            ViewBag.ProcSeries = _processorService.GetProcSeries();

            if (!ModelState.IsValid)
            {
                return View();
            }

            var processorPostDto = await _processorService.CreateAsync(postDTO);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ProcSeries = _processorService.GetProcSeries();
            
            ProcessorPostDTO postDTO = await _processorService.GetByIdAsync(id);

            return View(postDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProcessorPostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _processorService.UpdateAsync(id, postDTO);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _processorService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Restore(int id)
        {
            await _processorService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
