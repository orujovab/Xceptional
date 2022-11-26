using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]
        public IActionResult Index(int page = 1)
        {
            return View(_categoryService.GetAllProd(page));
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDto postDto)
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
            }

            var processorPostDto = await _categoryService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Edit(int id)
        {
            CategoryPostDto postDTO = await _categoryService.GetByIdAsync(id);
            return View(postDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryPostDto postDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
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
            }
            await _categoryService.UpdateAsync(id, postDTO);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Restore(int id)
        {
            await _categoryService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
