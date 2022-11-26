using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.Helpers;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class BrandController : Controller
    {
        private IBrandService _brandService;
        private IWebHostEnvironment _env;
        public BrandController(IBrandService brandService, IWebHostEnvironment env)
        {
            _brandService = brandService;
            _env = env;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]
        public IActionResult Index(int page = 1)
        {
            return View(_brandService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (postDto.ImageFile != null)
            {
                if (postDto.ImageFile.ContentType != "image/jpeg" && postDto.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "file type must be image/jpeg or image/png");
                    return View();
                }

                if (postDto.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "file size must be less than 2mb");
                    return View();
                }
                postDto.Image = FileManager.Save(_env.WebRootPath, "uploads/brands", postDto.ImageFile);
            }

            var getDto = await _brandService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Edit(int id)
        {
            BrandPostDto postDTO = await _brandService.GetByIdAsync(id);
            return View(postDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BrandPostDto postDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existBrand = await _brandService.GetBrandAsync(id);

            if (postDTO.ImageFile != null)
            {
                if (postDTO.ImageFile.ContentType != "image/jpeg" && postDTO.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "file type must be image/jpeg or image/png");
                    return View();
                }

                if (postDTO.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "file size must be less than 2mb");
                    return View();
                }
                string newImage = FileManager.Save(_env.WebRootPath, "uploads/brands", postDTO.ImageFile);
                postDTO.Image = newImage;

                if (existBrand.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/brands", existBrand.Image);
                }
                existBrand.Image = postDTO.Image;
            }

            await _brandService.UpdateAsync(existBrand, postDTO);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _brandService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Restore(int id)
        {
            await _brandService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
