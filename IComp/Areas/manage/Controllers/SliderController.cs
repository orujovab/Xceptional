using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.Exceptions;
using IComp.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public SliderController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]
        public IActionResult Index(int page = 1)
        {
            var query = _unitOfWork.SliderRepository.GetAll();
            int pageSize = 3;

            List<Slider> items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var paginatedList = new PaginatedListDto<Slider>(items, query.Count(), page, pageSize);

            return View(paginatedList);
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (slider.IsFirst == true && slider.IsSecond == true)
            {
                throw new RecordDuplicatedException("");
            }
            else if(slider.IsFirst == false && slider.IsSecond == false)
            {
                throw new RecordDuplicatedException("");
            }
            var query = _unitOfWork.SliderRepository.GetAll();

            query = query.OrderByDescending(x => x.Order);

            var lastSlider = query.FirstOrDefault();
            

            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image file is required");
                return View();
            }
            if (!(slider.ImageFile.ContentType == "image/jpeg") && !(slider.ImageFile.ContentType == "image/png"))
            {
                ModelState.AddModelError("ImageFile", "only .jpeg or .png files needed");
                return View();
            }
            if (slider.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "The size of this file is more than 2 GB");
                return View();

            }

            slider.Image = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.ImageFile);

            slider.Order = lastSlider.Order;
            slider.Order++;


            await _unitOfWork.SliderRepository.AddAsync(slider);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Edit(int id)
        {
            var slider = await _unitOfWork.SliderRepository.GetAsync(x => x.Id == id);

            if (slider == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (slider.IsFirst == true && slider.IsSecond == true)
            {
                throw new RecordDuplicatedException("");
            }
            else if (slider.IsFirst == false && slider.IsSecond == false)
            {
                throw new RecordDuplicatedException("");
            }
            var existSlider = await _unitOfWork.SliderRepository.GetAsync(x => x.Id == id);

            if (existSlider == null) { return View(); }

            if (slider.ImageFile != null)
            {
                if (!(slider.ImageFile.ContentType == "image/jpeg") && !(slider.ImageFile.ContentType == "image/png"))
                {
                    ModelState.AddModelError("ImageFile", "only .jpeg or .png files needed");
                    return View();
                }
                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "The size of this file is more than 2 GB");
                    return View();

                }

                slider.Image = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.ImageFile);

                FileManager.Delete(_env.WebRootPath, "uploads/sliders", existSlider.Image);
                
                existSlider.Image = slider.Image;
                
            }

            existSlider.Url = slider.Url;
            existSlider.IsFirst = slider.IsFirst;
            existSlider.IsSecond = slider.IsSecond;
            await _unitOfWork.CommitAsync();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Delete(int id)
        {
            var existSlider = await _unitOfWork.SliderRepository.GetAsync(x => x.Id == id);
            if (existSlider == null)
            {
                return View();
            }
            _unitOfWork.SliderRepository.Remove(existSlider);
            await _unitOfWork.CommitAsync();
            return RedirectToAction("Index");
        }
    }
}
