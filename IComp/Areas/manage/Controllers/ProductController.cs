using IComp.Core.Entities;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.ProductDTOs;
using IComp.Service.Helpers;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _env = env;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor")]

        public IActionResult Index(int? value, int page = 1)
        {
            var paginated = _productService.GetAllProd(value, page);

            ViewBag.Categories = _productService.GetCategories();
            ViewBag.CategoryId = value;

            return View(paginated);
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public IActionResult Create()
        {
            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.HardDiscs = _productService.GetHardDiscs();
            ViewBag.SSDs = _productService.GetSSDs();
            ViewBag.MotherBoards = _productService.GetMotherBoards();
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.Softwares = _productService.GetSoftwares();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto postDto)
        {
            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.HardDiscs = _productService.GetHardDiscs();
            ViewBag.SSDs = _productService.GetSSDs();
            ViewBag.SSDs = _productService.GetSSDs();
            ViewBag.MotherBoards = _productService.GetMotherBoards();
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.Softwares = _productService.GetSoftwares();

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (postDto.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "PosterFile is required");
                return View();
            }
            else
            {
                if (postDto.PosterFile.ContentType != "image/jpeg" && postDto.PosterFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("PosterFile", "file type must be image/jpeg or image/png");
                    return View();
                }

                if (postDto.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "file size must be less than 2mb");
                    return View();
                }
            }

            if (postDto.ImageFiles != null)
            {
                foreach (var file in postDto.ImageFiles)
                {
                    if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                    {
                        ModelState.AddModelError("ImageFiles", "file type must be image/jpeg or image/png");
                        return View();
                    }

                    if (file.Length > 2097152)
                    {
                        ModelState.AddModelError("ImageFiles", "file size must be less than 2mb");
                        return View();
                    }
                }
            }
            postDto.ProductImages = new List<ProductImage>();

            ProductImage posterImage = new ProductImage
            {
                PosterStatus = true,
                Image = FileManager.Save(_env.WebRootPath, "uploads/products", postDto.PosterFile)
            };
            postDto.ProductImages.Add(posterImage);

            if (postDto.ImageFiles != null)
            {
                foreach (var file in postDto.ImageFiles)
                {
                    ProductImage productImage = new ProductImage
                    {
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/products", file)
                    };
                    postDto.ProductImages.Add(productImage);
                }
            }

            var getDto = await _productService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Edit(int id)
        {
            var existProduct = await _productService.GetByIdAsync(id);

            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.HardDiscs = _productService.GetHardDiscs();
            ViewBag.SSDs = _productService.GetSSDs();
            ViewBag.MotherBoards = _productService.GetMotherBoards();
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.Softwares = _productService.GetSoftwares();

            return View(existProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductPostDto postDto)
        {
            var existProduct = await _productService.GetByIdAsync(id);

            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.HardDiscs = _productService.GetHardDiscs();
            ViewBag.SSDs = _productService.GetSSDs();
            ViewBag.MotherBoards = _productService.GetMotherBoards();
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.Softwares = _productService.GetSoftwares();


            var processors = _productService.GetProcessors();
            var brands = _productService.GetBrands();
            var memories = _productService.GetMemories();
            var categories = _productService.GetCategories();
            var hardDiscs = _productService.GetHardDiscs();
            var ssDs = _productService.GetSSDs();
            var motherBoards = _productService.GetMotherBoards();
            var videoCards = _productService.GetVideoCards();
            var destinations = _productService.GetDestinations();
            var prodTypes = _productService.GetProdTypes();
            var colors = _productService.GetColors();
            var softwares = _productService.GetSoftwares();

            if (!processors.Any(x => x.Id == postDto.ProcessorId && !x.IsDeleted))
            {
                ModelState.AddModelError("ProcessorId", "Processor not found");
            }
            if (!brands.Any(x => x.Id == postDto.BrandId && !x.IsDeleted))
            {
                ModelState.AddModelError("BrandId", "Brand not found");
            }
            if (!memories.Any(x => x.Id == postDto.ProdMemoryId && !x.IsDeleted))
            {
                ModelState.AddModelError("ProdMemoryId", "Memory not found");
            }
            if (!categories.Any(x => x.Id == postDto.CategoryId && !x.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Category not found");
            }
            if (!hardDiscs.Any(x => x.Id == postDto.HardDiscId && !x.IsDeleted))
            {
                ModelState.AddModelError("HardDiscId", "Harddisc not found");
            }
            if (!motherBoards.Any(x => x.Id == postDto.MotherBoardId && !x.IsDeleted))
            {
                ModelState.AddModelError("MotherBoardId", "MotherBoard not found");
            }
            if (!videoCards.Any(x => x.Id == postDto.VideoCardId && !x.IsDeleted))
            {
                ModelState.AddModelError("VideoCardId", "VideoCard not found");
            }
            if (!destinations.Any(x => x.Id == postDto.DestinationId && !x.IsDeleted))
            {
                ModelState.AddModelError("DestinationId", "Destination not found");
            }
            if (!prodTypes.Any(x => x.Id == postDto.ProdTypeId && !x.IsDeleted))
            {
                ModelState.AddModelError("ProdTypeId", "productType not found");
            }
            if (!colors.Any(x => x.Id == postDto.ColorId && !x.IsDeleted))
            {
                ModelState.AddModelError("ColoId", "color not found");
            }
            if (!softwares.Any(x => x.Id == postDto.SoftwareId && !x.IsDeleted))
            {
                ModelState.AddModelError("SoftwareId", "Os not found");
            }

            if (postDto.PosterFile != null && postDto.PosterFile.ContentType != "image/jpeg" && postDto.PosterFile.ContentType != "image/png")
            {
                ModelState.AddModelError("PosterFile", "file type must be image/jpeg or image/png");
                return View(existProduct);
            }

            if (postDto.PosterFile != null && postDto.PosterFile.Length > 2097152)
            {
                ModelState.AddModelError("PosterFile", "file size must be less than 2mb");
                return View(existProduct);
            }

            if (postDto.ImageFiles != null)
            {
                foreach (var file in postDto.ImageFiles)
                {
                    if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                    {
                        ModelState.AddModelError("ImageFiles", "file type must be image/jpeg or image/png");
                        return View(existProduct);
                    }

                    if (file.Length > 2097152)
                    {
                        ModelState.AddModelError("ImageFiles", "file size must be less than 2mb");
                        return View(existProduct);
                    }
                }
            }

            ProductImage poster = existProduct.ProductImages.FirstOrDefault(x => x.PosterStatus == true);

            if (postDto.PosterFile != null)
            {
                string newPosterImg = FileManager.Save(_env.WebRootPath, "uploads/products", postDto.PosterFile);
                if (poster != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/products", poster.Image);
                    poster.Image = newPosterImg;
                }
                else
                {
                    poster = new ProductImage { Image = newPosterImg, PosterStatus = true };
                    existProduct.ProductImages.Add(poster);
                }
            }

            if (postDto.ImageFiles != null)
            {
                foreach (var file in postDto.ImageFiles)
                {
                    ProductImage productImage = new ProductImage
                    {
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/products", file)
                    };
                    existProduct.ProductImages.Add(productImage);
                }
            }

            existProduct.ProcessorId = postDto.ProcessorId;
            existProduct.CategoryId = postDto.CategoryId;
            existProduct.BrandId = postDto.BrandId;
            existProduct.DestinationId = postDto.DestinationId;
            existProduct.HardDiscId = postDto.HardDiscId;
            existProduct.SSDId = postDto.SSDId;
            existProduct.ProdMemoryId = postDto.ProdMemoryId;
            existProduct.MotherBoardId = postDto.MotherBoardId;
            existProduct.ProdTypeId = postDto.ProdTypeId;
            existProduct.VideoCardId = postDto.VideoCardId;
            existProduct.ColorId = postDto.ColorId;
            existProduct.SoftwareId = postDto.SoftwareId;
            existProduct.Name = postDto.Name;
            existProduct.SalePrice = postDto.SalePrice;
            existProduct.CostPrice = postDto.CostPrice;
            existProduct.DiscountPercent = postDto.DiscountPercent;
            existProduct.Count = postDto.Count;
            existProduct.IsAvailable = postDto.IsAvailable;
            existProduct.IsNew = postDto.IsNew;
            existProduct.IsFeatured = postDto.IsFeatured;
            existProduct.IsPopular = postDto.IsPopular;
            existProduct.HasBluetooth = postDto.HasBluetooth;
            existProduct.HasWifi = postDto.HasWifi;
            existProduct.SoundType = postDto.SoundType;
            existProduct.InputPorts = postDto.InputPorts;
            existProduct.USB = postDto.USB;
            existProduct.USBTypeC = postDto.USBTypeC;
            existProduct.Network = postDto.Network;
            existProduct.PowerSupply = postDto.PowerSupply;
            existProduct.Weight = postDto.Weight;
            existProduct.WarrantyPeriod = postDto.WarrantyPeriod;

            await _productService.UpdateAsync(id, existProduct);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> DeleteImage(int id)
        {
            var productImage = await _productService.GetProductImage(id);

            FileManager.Delete(_env.WebRootPath, "uploads/products", productImage.Image);

            await _productService.DeleteProductImage(productImage);

            return Ok();
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin, Admin, Editor")]

        public async Task<IActionResult> Restore(int id)
        {
            await _productService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
