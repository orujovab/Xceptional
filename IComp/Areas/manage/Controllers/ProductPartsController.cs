using AutoMapper;
using IComp.Core.Entities;
using IComp.Service.DTOs.ProductDTOs;
using IComp.Service.DTOs.ProductPartsDTOs;
using IComp.Service.Helpers;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]

    public class ProductPartsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;


        public ProductPartsController(IProductService productService, IWebHostEnvironment env, IMapper mapper)
        {
            _productService = productService;
            _env = env;
            _mapper = mapper;
        }

        public IActionResult CreateProcessor()
        {
            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcessor(ProdProcessorPostDto postDto)
        {
            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();


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

            ProductPostDto productPost = _mapper.Map<ProductPostDto>(postDto);
            await _productService.CreateAsync(productPost);
            return RedirectToAction("index","product");
        }

        public IActionResult CreateMotherBoard()
        {
            ViewBag.Motherboards = _productService.GetMotherBoards();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMotherBoard(ProdMotherBoardDto postDto)
        {
            ViewBag.Motherboards = _productService.GetMotherBoards();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();

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

            ProductPostDto productPost = _mapper.Map<ProductPostDto>(postDto);
            await _productService.CreateAsync(productPost);
            return RedirectToAction("index", "product");
        }

        public IActionResult CreateRam()
        {
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRam(ProdRamDto postDto)
        {
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();

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

            ProductPostDto productPost = _mapper.Map<ProductPostDto>(postDto);
            await _productService.CreateAsync(productPost);
            return RedirectToAction("index", "product");
        }

        public IActionResult CreateVideoCard()
        {
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVideoCard(ProdVideoCardDto postDto)
        {
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();

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

            ProductPostDto productPost = _mapper.Map<ProductPostDto>(postDto);
            await _productService.CreateAsync(productPost);
            return RedirectToAction("index", "product");
        }

        public IActionResult CreateCooler()
        {
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCooler(ProdCoolerDto postDto)
        {
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();

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

            ProductPostDto productPost = _mapper.Map<ProductPostDto>(postDto);
            await _productService.CreateAsync(productPost);
            return RedirectToAction("index", "product");
        }

        public IActionResult CreateSSD()
        {
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.SSDs = _productService.GetSSDs();


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSSD(ProdSSDDto postDto)
        {
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.SSDs = _productService.GetSSDs();

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

            ProductPostDto productPost = _mapper.Map<ProductPostDto>(postDto);
            await _productService.CreateAsync(productPost);
            return RedirectToAction("index", "product");
        }

        public IActionResult CreateHDD()
        {
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.HDDs = _productService.GetHardDiscs();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateHDD(ProdHddDto postDto)
        {
            ViewBag.ProdTypes = _productService.GetProdTypes();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.Colors = _productService.GetColors();
            ViewBag.HDDs = _productService.GetHardDiscs();

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

            ProductPostDto productPost = _mapper.Map<ProductPostDto>(postDto);
            await _productService.CreateAsync(productPost);
            return RedirectToAction("index", "product");
        }
        public IActionResult CreateOpticDrive()
        {

            return View();
        }
       
    }
}
