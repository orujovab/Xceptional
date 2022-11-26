using IComp.Core.Entities;
using IComp.Service.DTOs.MotherBoardDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class MotherBoardController : Controller
    {
        private readonly IMotherBoardService _motherBoardService;

        public MotherBoardController(IMotherBoardService motherBoardService)
        {
            _motherBoardService = motherBoardService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_motherBoardService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MotherBoardPostDto motherBoard)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _motherBoardService.CreateAsync(motherBoard);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _motherBoardService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Restore(int id)
        {
            await _motherBoardService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _motherBoardService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, MotherBoardPostDto motherBoard)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _motherBoardService.UpdateAsync(id, motherBoard);
            return RedirectToAction("Index");
        }
    }
}
