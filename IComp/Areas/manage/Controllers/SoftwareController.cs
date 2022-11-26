using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class SoftwareController : Controller
    {
        private readonly ISoftwareService _softwareService;

        public SoftwareController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int page = 1)
        {
            return View(_softwareService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(Software software)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _softwareService.CreateAsync(software);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public async Task<IActionResult> Edit(int id) { return View(await _softwareService.GetByIdAsync(id)); }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Software software)
        {
            if (!ModelState.IsValid)
            {
                return View(); 
            }
            await _softwareService.UpdateAsync(id, software);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader")]

        public async Task<IActionResult> Delete(int id) { await _softwareService.DeleteAsync(id); return RedirectToAction("Index"); }
    }
}
