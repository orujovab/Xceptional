using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class VideoCardSerieController : Controller
    {
        private readonly IVCSerieService _vcSerieService;
        public VideoCardSerieController(IVCSerieService procSerieService)
        {
            _vcSerieService = procSerieService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_vcSerieService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VCSeriePostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _vcSerieService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public async Task<IActionResult> Delete(int id)
        {
            await _vcSerieService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public async Task<IActionResult> Edit(int id)
        {
            VCSeriePostDto postDto = await _vcSerieService.GetByIdAsync(id);
            return View(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VCSeriePostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _vcSerieService.UpdateAsync(id, postDto);
            return RedirectToAction("Index");
        }
    }
}
