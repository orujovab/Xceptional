using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProcessorserieController : Controller
    {
        private readonly IProcessorSerieService _procSerieService;
        public ProcessorserieController(IProcessorSerieService procSerieService)
        {
            _procSerieService = procSerieService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_procSerieService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProcessorSeriePostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _procSerieService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _procSerieService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            ProcessorSeriePostDto postDto = await _procSerieService.GetByIdAsync(id);
            return View(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProcessorSeriePostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _procSerieService.UpdateAsync(id, postDto);
            return RedirectToAction("Index");
        }
    }
}
