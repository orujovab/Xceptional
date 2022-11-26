using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Data;
using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.DTOs.ColorDTOs;
using IComp.Service.DTOs.DestinationDTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.DTOs.MemoryDTOs;
using IComp.Service.DTOs.MotherBoardDTOs;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.DTOs.ProdTypeDTOs;
using IComp.Service.DTOs.ProductDTOs;
using IComp.Service.DTOs.SoftwareDTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.DTOs.VideoCardDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.Utils;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _env = env;
        }


        public async Task<ProductGetDTO> CreateAsync(ProductPostDto postDTO)
        {
            if (await _unitOfWork.ProductRepository.IsExistAsync(x => x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.Name);
            }

            if (!await _unitOfWork.VideoCardRepository.IsExistAsync(x => x.Id == postDTO.VideoCardId && !x.IsDeleted))
            {
                if (postDTO.VideoCardId != 0)
                {

                }
            }
            if (!await _unitOfWork.ProcessorRepository.IsExistAsync(x => x.Id == postDTO.ProcessorId && !x.IsDeleted))
            {
                if (postDTO.ProcessorId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.MotherBoardRepository.IsExistAsync(x => x.Id == postDTO.MotherBoardId && !x.IsDeleted))
            {
                if (postDTO.MotherBoardId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.HardDiscRepository.IsExistAsync(x => x.Id == postDTO.HardDiscId && !x.IsDeleted))
            {
                if (postDTO.HardDiscId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.SSDRepository.IsExistAsync(x => x.Id == postDTO.SSDId && !x.IsDeleted))
            {
                if (postDTO.SSDId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.ColorRepository.IsExistAsync(x => x.Id == postDTO.ColorId))
            {
                if (postDTO.ColorId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == postDTO.CategoryId && !x.IsDeleted))
            {
                if (postDTO.CategoryId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.BrandRepository.IsExistAsync(x => x.Id == postDTO.BrandId && !x.IsDeleted))
            {
                if (postDTO.BrandId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.DestinationRepository.IsExistAsync(x => x.Id == postDTO.DestinationId))
            {
                if (postDTO.DestinationId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.ProdTypeRepository.IsExistAsync(x => x.Id == postDTO.ProdTypeId))
            {
                if (postDTO.ProdTypeId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.SoftWareRepository.IsExistAsync(x => x.Id == postDTO.SoftwareId))
            {
                if (postDTO.SoftwareId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }

            Product product = _mapper.Map<Product>(postDTO);

            if (postDTO.SSDId == 0)
            {
                product.SSDId = default;
            }
            if (postDTO.HardDiscId == 0)
            {
                product.HardDiscId = default;
            }
            if (postDTO.VideoCardId == 0)
            {
                product.VideoCardId = default;
            }
            if (postDTO.MotherBoardId == 0)
            {
                product.MotherBoardId = default;
            }
            if (postDTO.ColorId == 0)
            {
                product.ColorId = default;
            }
            if (postDTO.BrandId == 0)
            {
                product.BrandId = default;
            }
            if (postDTO.DestinationId == 0)
            {
                product.DestinationId = default;
            }
            if (postDTO.ProdTypeId == 0)
            {
                product.ProdTypeId = default;
            }
            if (postDTO.SoftwareId == 0)
            {
                product.SoftwareId = default;
            }
            if (postDTO.ProdMemoryId == 0)
            {
                product.ProdMemoryId = default;
            }
            if (postDTO.ProcessorId == 0)
            {
                product.ProcessorId = default;
            }
            if (product.IsAvailable == false)
            {
                product.IsAvailable = true;
            }
            if (product.Count == 0)
            {
                product.Count = 1;
            }

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();

            return new ProductGetDTO
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (product == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            product.IsDeleted = true;
            product.IsAvailable = false;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<ProductListItemDto> GetAllProd(int? value, int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll();

            if (value != null)
            {
                query = query.Where(x => x.CategoryId == value);
            }

            var pageSize = 3;

            List<ProductListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProductListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Count,
                IsDeleted = x.IsDeleted,
                ProductImages = x.ProductImages,
                SalePrice = x.SalePrice,
                CostPrice = x.CostPrice,
                DiscountPercent = x.DiscountPercent,
                Processor = x.Processor,
                HardDisc = x.HardDisc,
                Brand = x.Brand,
                Category = x.Category,
                Destination = x.Destination,
                MotherBoard = x.MotherBoard,
                ProdMemory = x.ProdMemory,
                VideoCard = x.VideoCard
            }).ToList();

            var listDto = new PaginatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }



        public async Task<PaginatedListDto<ProductListItemDto>> FilterProd(decimal? minprice, decimal? maxprice, string sort, int? softwareid, int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? prodmemorycapacityid, int? brandid, int? destinationid, int? harddiscapacitycid, int? ssdcapacityid, int? categoryid, int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll(x => !x.IsDeleted, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software");

            if (processorserieid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.Processor.ProcessorSerieId == processorserieid);
            }
            if (videocardserieid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.VideoCard.VideoCardSerieId == videocardserieid);
            }
            if (motherboardid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.MotherBoardId == motherboardid);
            }
            if (destinationid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.DestinationId == destinationid);
            }
            if (prodtypeid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.ProdTypeId == prodtypeid);
            }
            if (prodmemorycapacityid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.ProdMemory.MemoryCapacityId == prodmemorycapacityid);
            }
            if (brandid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.BrandId == brandid);
            }
            if (harddiscapacitycid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.HardDisc.HDDCapacityId == harddiscapacitycid);
            }
            if (ssdcapacityid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.SSD.SSDCapacityID == ssdcapacityid);
            }
            if (categoryid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.CategoryId == categoryid);
            }
            if (softwareid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.SoftwareId == softwareid);
            }


            switch (sort)
            {
                case "price_high":
                    query = _unitOfWork.ProductRepository.FilterByPrice(query, sort);
                    break;
                case "price_low":
                    query = _unitOfWork.ProductRepository.FilterByPrice(query, sort);
                    break;
                case "name_asc":
                    query = _unitOfWork.ProductRepository.FilterByNameAsc(query, sort);
                    break;
                case "name_desc":
                    query = _unitOfWork.ProductRepository.FilterByNameAsc(query, sort);
                    break;
                case "popular":
                    query = query.OrderByDescending(x => x.IsPopular);
                    break;
                default:
                    break;
            }

            if (minprice != null && maxprice != null)
            {
                query = query.Where(x => x.DiscountPercent > 0 ? (Math.Floor(x.SalePrice * (1 - x.DiscountPercent / 100)) >= minprice && Math.Floor(x.SalePrice * (1 - x.DiscountPercent / 100)) <= maxprice) : (x.SalePrice >= minprice && x.SalePrice <= maxprice));
            }



            NumberFormatInfo nfi = new NumberFormatInfo();

            nfi.NumberDecimalSeparator = ".";


            var key = await _unitOfWork.SettingRepository.GetAsync(x => x.Key == "CatalogPageSize");
            var pageSize = int.Parse(key.Value);

            List<ProductListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProductListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Count,
                IsDeleted = x.IsDeleted,
                ProductImages = x.ProductImages,
                SalePrice = x.SalePrice,
                CostPrice = x.CostPrice,
                DiscountPercent = x.DiscountPercent,
                Processor = x.Processor,
                HardDisc = x.HardDisc,
                Brand = x.Brand,
                Category = x.Category,
                Destination = x.Destination,
                MotherBoard = x.MotherBoard,
                ProdMemory = x.ProdMemory,
                VideoCard = x.VideoCard,
                SSD = x.SSD,
                Color = x.Color,
                Software = x.Software,
                IsAvailable = x.IsAvailable,
                Speed = x.Speed,
                Network = x.Network,
                ProcessorId = x.ProcessorId,
                BrandId = x.BrandId,
                DestinationId = x.DestinationId,
                HardDiscId = x.HardDiscId,
                SSDId = x.SSDId,
                ProdMemoryId = x.ProdMemoryId,
                MotherBoardId = x.MotherBoardId,
                ProdTypeId = x.ProdTypeId,
                VideoCardId = x.VideoCardId,
                ColorId = x.ColorId,
                SoftwareId = x.SoftwareId,
                CategoryId = x.CategoryId,
            }).ToList();

            var listDto = new PaginatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public decimal FilterByPrice(string val)
        {
            if (val == "max")
                return _unitOfWork.ProductRepository.FilterByPriceRange("max");
            else if (val == "min")
                return _unitOfWork.ProductRepository.FilterByPriceRange("min");
            return 0;
        }

        public async Task<ProductPostDto> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id, "ProductImages");

            if (product == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<ProductPostDto>(product);
        }

        public async Task<DetailViewModel> FindByIdAsync(int id)
        {
            var existProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted, "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Category", "Color", "Software", "ProductImages", "ProductComments.AppUser", "ProductComments.Product");

            AppUser appUser = null;
            DetailViewModel viewModel = new DetailViewModel();
            viewModel.CheckedProducts = new List<ProductGetDTO>();

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            }
            if (existProduct == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (appUser != null)
            {
                var checkedProds = _unitOfWork.CheckedProductsRepository.GetAll(x => x.AppUserId == appUser.Id).Take(12);

                if (!checkedProds.Any(x => x.ProductId == existProduct.Id))
                {
                    var item = new CheckedProducts
                    {
                        AppUserId = appUser.Id,
                        ProductId = existProduct.Id
                    };
                    await _unitOfWork.CheckedProductsRepository.AddAsync(item);
                    await _unitOfWork.CommitAsync();

                    var cProdsList = await checkedProds.ToListAsync();

                    foreach (var item2 in cProdsList)
                    {
                        var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item2.ProductId && !x.IsDeleted, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software");
                        var dto = _mapper.Map<ProductGetDTO>(product);
                        viewModel.CheckedProducts.Add(dto);
                    }

                }
                else
                {
                    var cProdsList = await checkedProds.ToListAsync();

                    foreach (var item2 in cProdsList)
                    {
                        var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item2.ProductId && !x.IsDeleted, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software");
                        var dto = _mapper.Map<ProductGetDTO>(product);
                        viewModel.CheckedProducts.Add(dto);
                    }
                }
            }
            else
            {
                string cookie = _httpContextAccessor.HttpContext.Request.Cookies["lastchecks"];
                List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookie);
                }

                BasketCookieItemViewModel cookieItem = cookieItems.FirstOrDefault(x => x.ProductId == id);
                var product = await GetByIdAsync(id);
                if (product.IsDeleted)
                {
                    throw new ItemNotFoundException("This product isn't available");
                }
                if (product == null)
                {
                    throw new ItemNotFoundException("Item not found");
                }

                if (cookieItem == null)
                {
                    cookieItem = new BasketCookieItemViewModel { ProductId = id, Count = 1 };
                    cookieItems.Add(cookieItem);
                }
                else
                {
                    cookieItem.Count++;
                }

                cookie = JsonConvert.SerializeObject(cookieItems);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("lastchecks", cookie);

                if (appUser == null)
                {
                    string cookieItemsStr = _httpContextAccessor.HttpContext.Request.Cookies["lastchecks"];

                    if (!string.IsNullOrWhiteSpace(cookieItemsStr))
                    {
                        cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookieItemsStr);
                    }

                    foreach (var item in cookieItems)
                    {
                        var checkedProds = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId && !x.IsDeleted, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software");


                        var dto = _mapper.Map<ProductGetDTO>(checkedProds);

                        viewModel.CheckedProducts.Add(dto);
                    }
                    viewModel.CheckedProducts.Take(12);
                }

            }

            Random random = new Random();
            int number = random.Next(1, 8);

            var productDto = _mapper.Map<ProductGetDTO>(existProduct);
            var relatedProds = await _unitOfWork.ProductRepository.GetAll(x => (x.CategoryId == existProduct.CategoryId || x.DestinationId == existProduct.DestinationId || x.BrandId == existProduct.BrandId) && x.Id != existProduct.Id && !x.IsDeleted && x.IsAvailable, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software").Skip(number).Take(4).ToListAsync();
            if (relatedProds.Count < 4)
            {
                relatedProds = await _unitOfWork.ProductRepository.GetAll(x => (x.CategoryId == existProduct.CategoryId || x.BrandId == existProduct.BrandId) && x.Id != existProduct.Id, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software").Take(4).ToListAsync();
            }
            var dto2 = _mapper.Map<List<ProductGetDTO>>(relatedProds);
            viewModel.RelatedProducts = dto2;
            viewModel.Comment = new ProductComment { ProductId = id };
            viewModel.Product = productDto;

            return viewModel;
        }
        public List<BrandGetDto> GetBrands()
        {
            var brands = _unitOfWork.BrandRepository.GetAll(x => !x.IsDeleted, "Products").ToList();

            var brandsDto = _mapper.Map<List<BrandGetDto>>(brands);
            return brandsDto;
        }

        public List<CategoryGetDto> GetCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll(x => !x.IsDeleted, "Products");

            foreach (var item in categories)
            {
                item.Products = item.Products.Where(x => !x.IsDeleted && x.IsAvailable).ToList();
            }

            var categoryGetDtos = _mapper.Map<List<CategoryGetDto>>(categories.ToList());
            return categoryGetDtos;
        }

        public List<HardDiscGetDto> GetHardDiscs()
        {
            var hardDiscs = _unitOfWork.HardDiscRepository.GetAll(x => !x.IsDeleted, "HDDCapacity").ToList();

            var hardDiscGetDtos = _mapper.Map<List<HardDiscGetDto>>(hardDiscs);
            return hardDiscGetDtos;
        }

        public List<MemoryGetDto> GetMemories()
        {
            var memories = _unitOfWork.MemoryRepository.GetAll(x => !x.IsDeleted).ToList();

            var memoryGetDtos = _mapper.Map<List<MemoryGetDto>>(memories);
            return memoryGetDtos;
        }

        public List<MotherBoardGetDto> GetMotherBoards()
        {
            var motherBoards = _unitOfWork.MotherBoardRepository.GetAll(x => !x.IsDeleted, "Products").ToList();

            var motherBoardGetDtos = _mapper.Map<List<MotherBoardGetDto>>(motherBoards);
            return motherBoardGetDtos;
        }

        public List<ProcessorGetDto> GetProcessors()
        {
            var processors = _unitOfWork.ProcessorRepository.GetAll(x => !x.IsDeleted).ToList();

            var processorGetDtos = _mapper.Map<List<ProcessorGetDto>>(processors);
            return processorGetDtos;
        }

        public List<VideoCardGetDto> GetVideoCards()
        {
            var videoCards = _unitOfWork.VideoCardRepository.GetAll(x => !x.IsDeleted).ToList();

            var videoCardGetDtos = _mapper.Map<List<VideoCardGetDto>>(videoCards);
            return videoCardGetDtos;
        }

        public List<ProdTypeGetDto> GetProdTypes()
        {
            var prodTypes = _unitOfWork.ProdTypeRepository.GetAll("Products").ToList();

            var prodTypeGetDtos = _mapper.Map<List<ProdTypeGetDto>>(prodTypes);
            return prodTypeGetDtos;
        }

        public List<DestinationGetDto> GetDestinations()
        {
            var destinations = _unitOfWork.DestinationRepository.GetAll("Products").ToList();

            var destinationGetDtos = _mapper.Map<List<DestinationGetDto>>(destinations);
            return destinationGetDtos;
        }
        public async Task RestoreAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == product.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + product.Name);
            }
            if (product == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (product.Count == 0)
            {
                product.Count = 1;
            }
            product.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, ProductPostDto postDto)
        {
            var existProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProduct == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == postDto.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDto.Name);
            }
            if (!await _unitOfWork.VideoCardRepository.IsExistAsync(x => x.Id == postDto.VideoCardId && !x.IsDeleted))
            {
                if (postDto.VideoCardId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.ProcessorRepository.IsExistAsync(x => x.Id == postDto.ProcessorId && !x.IsDeleted))
            {
                if (postDto.ProcessorId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.MotherBoardRepository.IsExistAsync(x => x.Id == postDto.MotherBoardId && !x.IsDeleted))
            {
                if (postDto.MotherBoardId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.HardDiscRepository.IsExistAsync(x => x.Id == postDto.HardDiscId && !x.IsDeleted))
            {
                if (postDto.HardDiscId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.SSDRepository.IsExistAsync(x => x.Id == postDto.SSDId && !x.IsDeleted))
            {
                if (postDto.SSDId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.ColorRepository.IsExistAsync(x => x.Id == postDto.ColorId))
            {
                if (postDto.ColorId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == postDto.CategoryId && !x.IsDeleted))
            {
                if (postDto.CategoryId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.BrandRepository.IsExistAsync(x => x.Id == postDto.BrandId && !x.IsDeleted))
            {
                if (postDto.BrandId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.DestinationRepository.IsExistAsync(x => x.Id == postDto.DestinationId))
            {
                if (postDto.DestinationId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.ProdTypeRepository.IsExistAsync(x => x.Id == postDto.ProdTypeId))
            {
                if (postDto.ProdTypeId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }
            if (!await _unitOfWork.SoftWareRepository.IsExistAsync(x => x.Id == postDto.SoftwareId))
            {
                if (postDto.SoftwareId != 0)
                {
                    throw new ItemNotFoundException("Item not found");
                }
            }

            existProduct.ProcessorId = postDto.ProcessorId;
            existProduct.CategoryId = postDto.CategoryId;
            existProduct.BrandId = postDto.BrandId;
            existProduct.DestinationId = postDto.DestinationId;

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
            existProduct.ProductImages = postDto.ProductImages;

            if (postDto.HardDiscId == 0)
            {
                existProduct.HardDiscId = default;
            }
            else
            {
                existProduct.HardDiscId = postDto.HardDiscId;
            }
            if (postDto.SSDId == 0)
            {
                existProduct.SSDId = default;
            }
            else
            {
                existProduct.SSDId = postDto.SSDId;
            }
            if (postDto.Count == 0)
            {
                existProduct.IsDeleted = true;
                existProduct.IsAvailable = false;
            }
            if (postDto.VideoCardId == 0)
            {
                existProduct.VideoCardId = default;
            }
            if (postDto.MotherBoardId == 0)
            {
                existProduct.MotherBoardId = default;
            }
            if (postDto.ColorId == 0)
            {
                existProduct.ColorId = default;
            }
            if (postDto.BrandId == 0)
            {
                existProduct.BrandId = default;
            }
            if (postDto.DestinationId == 0)
            {
                existProduct.DestinationId = default;
            }
            if (postDto.ProdTypeId == 0)
            {
                existProduct.ProdTypeId = default;
            }
            if (postDto.SoftwareId == 0)
            {
                existProduct.SoftwareId = default;
            }
            if (postDto.ProdMemoryId == 0)
            {
                existProduct.ProdMemoryId = default;
            }
            if (postDto.ProcessorId == 0)
            {
                existProduct.ProcessorId = default;
            }
            //if (existProduct.IsAvailable == false)
            //{
            //    existProduct.IsAvailable = true;
            //}

            await _unitOfWork.CommitAsync();
        }
        public List<ProcessorSerieGetDto> GetProcessirSeries()
        {
            var proc = _unitOfWork.ProcessorSerieRepository.GetAll("Processors.Products.Processor").ToList();

            var processorGets = _mapper.Map<List<ProcessorSerieGetDto>>(proc);
            return processorGets;
        }

        public List<HardDiscCapacityGetDto> GetHardDiscCapacities()
        {
            var capac = _unitOfWork.HardDiscCapacityRepository.GetAll("HardDiscs.Products").ToList();

            var capacityGetDtos = _mapper.Map<List<HardDiscCapacityGetDto>>(capac);
            return capacityGetDtos;
        }

        public List<MCapacityGetDto> GetMemoryCapacities()
        {
            var memoryCapacities = _unitOfWork.MemoryCapacityRepository.GetAll("Memories.Products").ToList();

            var capacityGetDtos = _mapper.Map<List<MCapacityGetDto>>(memoryCapacities);
            return capacityGetDtos;
        }

        public List<VCSerieGetDto> GetVideoCardSeries()
        {
            var series = _unitOfWork.VCSerieRepository.GetAll("VideoCards.Products").ToList();

            var serieGetDtos = _mapper.Map<List<VCSerieGetDto>>(series);
            return serieGetDtos;
        }

        public List<ColorGetDto> GetColors()
        {
            var colors = _unitOfWork.ColorRepository.GetAll().ToList();

            var colorGetDtos = _mapper.Map<List<ColorGetDto>>(colors);
            return colorGetDtos;
        }

        public List<SoftwareGetDto> GetSoftwares()
        {
            var softwares = _unitOfWork.SoftWareRepository.GetAll("Products").ToList();

            var softwareGetDtos = _mapper.Map<List<SoftwareGetDto>>(softwares);
            return softwareGetDtos;
        }

        public async Task<ProductImage> GetProductImage(int id)
        {
            var productImage = await _unitOfWork.ProductImageRepository.GetAsync(x => x.Id == id);

            if (productImage == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return productImage;
        }

        public async Task DeleteProductImage(ProductImage productImage)
        {
            _unitOfWork.ProductImageRepository.Remove(productImage);

            await _unitOfWork.CommitAsync();
        }

        public Dictionary<string, string> GetSettings()
        {
            var settings = _unitOfWork.SettingRepository.GetAll().ToDictionary(x => x.Key, x => x.Value);

            return settings;
        }


        public async Task<CommonBasketViewModel> _getBasket(List<BasketCookieItemViewModel> basketItems)
        {

            CommonBasketViewModel basketVM = new CommonBasketViewModel
            {
                BasketItems = new List<BasketProductViewModel>(),
                TotalPrice = 0
            };


            foreach (var item in basketItems)
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId, "ProductImages");

                BasketProductViewModel basketBook = new BasketProductViewModel
                {
                    Product = product,
                    Count = item.Count
                };

                basketVM.BasketItems.Add(basketBook);
                decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                basketVM.TotalPrice += totalPrice * item.Count;
            }

            return basketVM;
        }

        public async Task<CommonBasketViewModel> _getBasket(List<BasketItem> cardItems)
        {
            CommonBasketViewModel cardVM = new CommonBasketViewModel
            {
                BasketItems = new List<BasketProductViewModel>(),
                TotalPrice = 0
            };

            foreach (var item in cardItems)
            {
                Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId, "ProductImages");
                BasketProductViewModel basketProductVM = new BasketProductViewModel
                {
                    Product = product,
                    Count = item.Count
                };

                cardVM.BasketItems.Add(basketProductVM);
                decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                cardVM.TotalPrice += totalPrice * item.Count;
            }
            return cardVM;
        }

        public async Task<bool> AnyProd(int id)
        {
            return await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<List<BasketItem>> UserBasket(int id, AppUser appUser)
        {
            BasketItem item = await _unitOfWork.BasketItemRepository.GetAsync(x => x.AppUserId == appUser.Id && x.ProductId == id);

            var product = await GetByIdAsync(id);

            if (product.IsAvailable == false || product.IsDeleted)
            {
                throw new ItemNotFoundException("This product isn't available");
            }
            if (product == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (product.Count <= item?.Count)
            {
                throw new ItemNotFoundException("There are only " + product.Count + " products in stock");
            }

            if (item == null)
            {
                item = new BasketItem
                {
                    AppUserId = appUser.Id,
                    ProductId = id,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    Count = 1
                };
                await _unitOfWork.BasketItemRepository.AddAsync(item);
            }
            else
            {
                item.Count++;
            }
            await _unitOfWork.CommitAsync();

            var items = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).ToList();
            return items;
        }

        public async Task<CommonBasketViewModel> DeleteBasket(int id)
        {
            if (!await AnyProd(id))
            {
                throw new ItemNotFoundException("Item not found");
            }

            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            if (appUser == null)
            {
                string cookie = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
                List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookie);
                }

                BasketCookieItemViewModel cookieItem = cookieItems.FirstOrDefault(x => x.ProductId == id);
                var product = await GetByIdAsync(id);

                if (cookieItem.Count > 1)
                {
                    cookieItem.Count--;
                }
                else
                {
                    cookieItems.Remove(cookieItem);
                }

                cookie = JsonConvert.SerializeObject(cookieItems);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("basket", cookie);

                return await _getBasket(cookieItems);
            }
            else
            {
                BasketItem item = await _unitOfWork.BasketItemRepository.GetAsync(x => x.AppUserId == appUser.Id && x.ProductId == id);

                var product = await GetByIdAsync(id);

                if (product == null)
                {
                    throw new ItemNotFoundException("Item not found");
                }
                if (product.Count < item?.Count)
                {
                    throw new Exception();
                }

                if (item.Count > 1)
                {
                    item.Count--;
                }
                else
                {
                    _unitOfWork.BasketItemRepository.Remove(item);
                }
                await _unitOfWork.CommitAsync();

                var items = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).ToList();
                return await _getBasket(items);
            }
        }

        public async Task<List<Product>> SearchProd(string searchString, int? maxProdCount)
        {
            var products = _unitOfWork.ProductRepository.GetAll(x => !x.IsDeleted, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software");

            if (!String.IsNullOrEmpty(searchString))
            {
                if (maxProdCount == null)
                {
                    products = products.Where(s => s.Name.Trim().ToLower().Contains(searchString.Trim().ToLower()));
                }
                else
                {
                    products = products.Where(s => s.Name.Trim().ToLower().Contains(searchString.Trim().ToLower())).Take(maxProdCount ?? 6);
                }
            }
            else
            {
                products = null;
            }


            return await products.ToListAsync();
        }

        public async Task<PaginatedListDto<ProductGetDTO>> SearchProdAll(string searchString,int page)
        {
            var products = _unitOfWork.ProductRepository.GetAll(x => !x.IsDeleted, "ProductImages", "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software");

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Trim().ToLower().Contains(searchString.Trim().ToLower()));
            }
            else
            {
                products = null;
            }

            var showProd = products.Skip((page - 1) * 8).Take(8).ToList();
            var dto = _mapper.Map<List<ProductGetDTO>>(showProd);
            PaginatedListDto <ProductGetDTO> listDto = new PaginatedListDto<ProductGetDTO>(dto, products.Count(), page, 8);

            return listDto;
        }

        public async Task<int> Comment(ProductComment comment)
        {
            if (comment.Text.Length < 3)
            {
                throw new Exception("Short message");
            }
            if (String.IsNullOrEmpty(comment.Name))
            {
                comment.Name = "Anonymous";
            }

            AppUser appUser = null;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }


            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == comment.ProductId, "ProductComments");
            if (product == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            if (appUser == null)
            {
                comment.CreatedAt = DateTime.UtcNow.AddHours(4);
                await _unitOfWork.ProductCommentRepository.AddAsync(comment);
                product.Rate = (int)(Math.Ceiling(product.ProductComments.Sum(x => x.Rate) / (double)product.ProductComments.Count));
                await _unitOfWork.CommitAsync();
                return comment.ProductId;
            }
            comment.AppUserId = appUser.Id;
            comment.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _unitOfWork.ProductCommentRepository.AddAsync(comment);
            product.Rate = (int)Math.Ceiling(product.ProductComments.Sum(x => x.Rate) / (double)product.ProductComments.Count);
            await _unitOfWork.CommitAsync();
            return comment.ProductId;
        }

        public async Task<FastCheckOutViewModel> FastOrder(int id)
        {
            AppUser appUser = null;

            FastCheckOutViewModel model = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            if (appUser == null)
            {
                model = new FastCheckOutViewModel
                {
                    Product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted && x.IsAvailable, "ProductImages"),
                    Order = new Order()
                };
                return model;
            }

            model = new FastCheckOutViewModel
            {
                Product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id, "ProductImages"),
                Order = new Order
                {
                    FullName = appUser?.FullName,
                    Email = appUser?.Email,
                    Address = null,
                    Phone = null
                }
            };

            return model;
        }

        public async Task CreateOrder(int id, Order order, int prodcount, int ordercount)
        {
            AppUser appUser = null;
            FastCheckOutViewModel model = new FastCheckOutViewModel();
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            Guid guid = Guid.NewGuid();
            order.TrackId = $"{guid}";
            var path = String.Empty;

            if (appUser == null)
            {
                model = new FastCheckOutViewModel
                {
                    Order = order,
                    Product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id, "ProductImages"),
                };


                order.AppUserId = null;
                order.CreatedAt = DateTime.UtcNow.AddHours(4);
                order.ModifiedAt = DateTime.UtcNow.AddHours(4);
                order.Status = Core.Enums.OrderStatus.Pending;
                order.IsDeleted = false;
                order.OrderItems = new List<OrderItem>();
                if (model.Product.Count < prodcount || model.Product.Count < ordercount)
                {
                    throw new RecordDuplicatedException("");
                }
                if (model.Product.Count <= 1)
                {
                    model.Product.Count = model.Product.Count - 1;
                    model.Product.IsAvailable = false;
                    model.Product.IsDeleted = true;
                }
                else
                {
                    model.Product.Count = model.Product.Count - ordercount;
                    if (model.Product.Count == 0)
                    {
                        model.Product.IsAvailable = false;
                        model.Product.IsDeleted = true;
                    }
                }
                await _unitOfWork.CommitAsync();

                OrderItem orderItm = new OrderItem
                {
                    ProductId = model.Product.Id,
                    SalePrice = model.Product.SalePrice,
                    CostPrice = model.Product.CostPrice,
                    DiscountedPrice = model.Product.DiscountPercent > 0 ? (model.Product.SalePrice * (1 - model.Product.DiscountPercent / 100)) : model.Product.SalePrice,
                    Count = ordercount,
                };



                order.OrderItems.Add(orderItm);
                order.TotalPrice += orderItm.DiscountedPrice * orderItm.Count;


                string body = String.Empty;
                path = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplate.html";

                using (StreamReader streamReader = System.IO.File.OpenText(path))
                {
                    body = streamReader.ReadToEnd();
                }

                body = body.Replace("{fullname}", order.FullName);
                body = body.Replace("{date}", order.CreatedAt.ToString());
                body = body.Replace("{status}", order.Status.ToString());
                body = body.Replace("{trackid}", order.TrackId.ToString());
                body = body.Replace("{total}", order.TotalPrice.ToString());

                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(order.Email);
                mailMessage.From = new MailAddress(Constant.EmailAddress);
                mailMessage.Subject = "Sifarişiniz üçün təşəkkürlər";
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new NetworkCredential(Constant.EmailAddress, Constant.Password);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                smtp.Send(mailMessage);

                await _unitOfWork.OrderRepository.AddAsync(order);
                await _unitOfWork.CommitAsync();
                return;
            }

            model = new FastCheckOutViewModel
            {
                Order = order,
                Product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id, "ProductImages"),
            };

            order.AppUserId = appUser?.Id;
            order.CreatedAt = DateTime.UtcNow.AddHours(4);
            order.ModifiedAt = DateTime.UtcNow.AddHours(4);
            order.Status = Core.Enums.OrderStatus.Pending;
            order.OrderItems = new List<OrderItem>();
            if (model.Product.Count < prodcount || model.Product.Count < ordercount)
            {
                throw new RecordDuplicatedException("");
            }
            if (model.Product.Count <= 1)
            {
                model.Product.Count = model.Product.Count - 1;
                model.Product.IsAvailable = false;
                model.Product.IsDeleted = true;
            }
            else
            {
                model.Product.Count = model.Product.Count - ordercount;
                if (model.Product.Count == 0)
                {
                    model.Product.IsAvailable = false;
                    model.Product.IsDeleted = true;
                }
            }
            await _unitOfWork.CommitAsync();


            OrderItem orderItem = new OrderItem
            {
                ProductId = model.Product.Id,
                SalePrice = model.Product.SalePrice,
                CostPrice = model.Product.CostPrice,
                DiscountedPrice = model.Product.DiscountPercent > 0 ? (model.Product.SalePrice * (1 - model.Product.DiscountPercent / 100)) : model.Product.SalePrice,
                Count = ordercount
            };



            order.OrderItems.Add(orderItem);
            order.TotalPrice += orderItem.DiscountedPrice * orderItem.Count;

            path = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplate.html";

            Dictionary<string, string> replaces = new Dictionary<string, string>();
            replaces.Add("{fullname}", order.FullName.ToString());
            replaces.Add("{date}", order.CreatedAt.ToString());
            replaces.Add("{status}", order.Status.ToString());
            replaces.Add("{trackid}", order.TrackId.ToString());
            replaces.Add("{total}", order.TotalPrice.ToString());

            await EmailUtil.SendEmailAsync(order.Email, "Salam hörmətli müştəri", path, replaces);

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<ProductListItemDto> GetAllProdWithFilter(int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll(x => !x.IsDeleted && x.IsNew, "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software").OrderByDescending(x => x.CreatedAt);

            var setting = _unitOfWork.SettingRepository.GetAll().ToDictionary(x => x.Key, x => x.Value);

            var pageSize = int.Parse(setting.FirstOrDefault(x => x.Key == "HomePageSize").Value);

            List<ProductListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProductListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Count,
                IsDeleted = x.IsDeleted,
                IsNew = x.IsNew,
                CreatedAt = x.CreatedAt,
                ProductImages = x.ProductImages,
                SalePrice = x.SalePrice,
                CostPrice = x.CostPrice,
                DiscountPercent = x.DiscountPercent,
                Processor = x.Processor,
                HardDisc = x.HardDisc,
                Brand = x.Brand,
                Category = x.Category,
                Destination = x.Destination,
                MotherBoard = x.MotherBoard,
                ProdMemory = x.ProdMemory,
                VideoCard = x.VideoCard,
                IsAvailable = x.IsAvailable,
                Speed = x.Speed,
                Network = x.Network
            }).ToList();

            var listDto = new PaginatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public List<SSDCapacity> GetSSDCapacities()
        {
            var capacity = _unitOfWork.SSDCapacityRepository.GetAll().ToList();

            return capacity;
        }

        public List<SSD> GetSSDs()
        {
            var sSDs = _unitOfWork.SSDRepository.GetAll("SSDCapacity").ToList();

            return sSDs;
        }

        public List<Slider> GetSlider()
        {
            return _unitOfWork.SliderRepository.GetAll().ToList();
        }

        public async Task<CheckOutViewModel> CheckOut()
        {
            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            var basket = await GetBasketItems(appUser);

            if (basket.BasketItems.Count == 0)
            {
                throw new ItemNotFoundException("Basket Item Not found");
            }

            CheckOutViewModel checkOutVM = null;

            if (appUser == null)
            {
                checkOutVM = new CheckOutViewModel
                {
                    Basket = basket,
                    Order = new Order()
                };

                return checkOutVM;
            }

            checkOutVM = new CheckOutViewModel
            {
                Basket = basket,
                Order = new Order
                {
                    Email = appUser?.Email,
                    FullName = appUser?.FullName,
                    Phone = null,
                    Address = null
                }
            };

            return checkOutVM;
        }

        public async Task CreateOrder(Order order)
        {
            AppUser member = null;
            CheckOutViewModel checkoutVM = null;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            Guid guid = Guid.NewGuid();
            order.TrackId = $"{guid}";
            var path = String.Empty;

            var basket = await GetBasketItems(member);

            if (member == null)
            {
                if (basket.BasketItems.Count == 0)
                    throw new ItemNotFoundException("");
                checkoutVM = new CheckOutViewModel
                {
                    Basket = basket,
                    Order = order
                };

                order.CreatedAt = DateTime.UtcNow.AddHours(4);
                order.ModifiedAt = DateTime.UtcNow.AddHours(4);
                order.Status = Core.Enums.OrderStatus.Pending;
                order.OrderItems = new List<OrderItem>();



                foreach (var item in checkoutVM.Basket.BasketItems)
                {
                    if (item.Product.Count < item.Count)
                    {
                        throw new RecordDuplicatedException("");
                    }
                    if (item.Product.Count <= 1)
                    {
                        item.Product.Count = item.Product.Count - 1;
                        item.Product.IsAvailable = false;
                    }
                    else
                    {
                        item.Product.Count = item.Product.Count - item.Count;
                        if (item.Product.Count == 0)
                        {
                            item.Product.IsAvailable = false;
                        }
                    }


                    OrderItem orderItem = new OrderItem
                    {
                        ProductId = item.Product.Id,
                        SalePrice = item.Product.SalePrice,
                        CostPrice = item.Product.CostPrice,
                        DiscountedPrice = item.Product.DiscountPercent > 0 ? (item.Product.SalePrice * (1 - item.Product.DiscountPercent / 100)) : item.Product.SalePrice,
                        Count = item.Count
                    };

                    order.OrderItems.Add(orderItem);
                    order.TotalPrice += orderItem.DiscountedPrice * orderItem.Count;

                    path = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplate.html";

                    Dictionary<string, string> Replaces = new Dictionary<string, string>();
                    Replaces.Add("{fullname}", order.FullName.ToString());
                    Replaces.Add("{date}", order.CreatedAt.ToString());
                    Replaces.Add("{status}", order.Status.ToString());
                    Replaces.Add("{trackid}", order.TrackId.ToString());
                    Replaces.Add("{total}", order.TotalPrice.ToString());

                    await EmailUtil.SendEmailAsync(order.Email, "Sifarişiniz üçün təşəkkürlər", path, Replaces);
                }



                await _unitOfWork.OrderRepository.AddAsync(order);

                if (member == null)
                    _httpContextAccessor.HttpContext.Response.Cookies.Delete("basket");
                await _unitOfWork.CommitAsync();

                return;
            }

            if (basket.BasketItems.Count == 0)
                throw new ItemNotFoundException("");
            checkoutVM = new CheckOutViewModel
            {
                Basket = basket,
                Order = order
            };

            order.AppUserId = member?.Id;
            order.CreatedAt = DateTime.UtcNow.AddHours(4);
            order.ModifiedAt = DateTime.UtcNow.AddHours(4);
            order.Status = Core.Enums.OrderStatus.Pending;
            order.OrderItems = new List<OrderItem>();

            foreach (var item in checkoutVM.Basket.BasketItems)
            {
                if (item.Product.Count <= 1)
                {
                    item.Product.Count = item.Product.Count - 1;
                    item.Product.IsAvailable = false;
                    item.Product.IsDeleted = true;
                }
                else
                {
                    item.Product.Count = item.Product.Count - item.Count;
                    if (item.Product.Count == 0)
                    {
                        item.Product.IsAvailable = false;
                        item.Product.IsDeleted = true;
                    }
                }

                OrderItem orderItem = new OrderItem
                {
                    ProductId = item.Product.Id,
                    SalePrice = item.Product.SalePrice,
                    CostPrice = item.Product.CostPrice,
                    DiscountedPrice = item.Product.DiscountPercent > 0 ? (item.Product.SalePrice * (1 - item.Product.DiscountPercent / 100)) : item.Product.SalePrice,
                    Count = item.Count
                };

                order.OrderItems.Add(orderItem);
                order.TotalPrice += orderItem.DiscountedPrice * orderItem.Count;
            }

            path = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplate.html";

            Dictionary<string, string> replaces = new Dictionary<string, string>();
            replaces.Add("{fullname}", order.FullName.ToString());
            replaces.Add("{date}", order.CreatedAt.ToString());
            replaces.Add("{status}", order.Status.ToString());
            replaces.Add("{trackid}", order.TrackId.ToString());
            replaces.Add("{total}", order.TotalPrice.ToString());

            await EmailUtil.SendEmailAsync(order.Email, "Sifarişiniz üçün təşəkkürlər", path, replaces);

            await _unitOfWork.OrderRepository.AddAsync(order);

            if (member == null)
                _httpContextAccessor.HttpContext.Response.Cookies.Delete("basket");
            else
                _unitOfWork.BasketItemRepository.RemoveRange(_unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == member.Id));

            await _unitOfWork.CommitAsync();

            return;
        }

        public async Task<CommonBasketViewModel> GetBasketItems(AppUser appUser)
        {
            CommonBasketViewModel basketItems = new CommonBasketViewModel
            {
                BasketItems = new List<BasketProductViewModel>(),
                TotalPrice = 0
            };

            List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

            if (appUser == null)
            {
                string cookieItemsStr = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

                if (!string.IsNullOrWhiteSpace(cookieItemsStr))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookieItemsStr);
                }
            }   
            else
            {
                cookieItems = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).Select(b => new BasketCookieItemViewModel { ProductId = b.ProductId, Count = b.Count }).ToList();
            }

            foreach (var item in cookieItems)
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId && !x.IsDeleted && x.IsAvailable, "ProductImages");
                if (product != null)
                {
                    BasketProductViewModel basketProduct = new BasketProductViewModel
                    {
                        Product = product,
                        Count = item.Count
                    };

                    basketItems.BasketItems.Add(basketProduct);
                    decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                    basketItems.TotalPrice += totalPrice * item.Count;
                }
            }


            return basketItems;
        }

        public async Task<List<Order>> GetOrdersAsync(AppUser appUser)
        {
            var orders = await _unitOfWork.OrderRepository.GetAll(x => x.AppUserId == appUser.Id, "OrderItems.Product.Brand", "OrderItems.Product.Category").ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            var order = await _unitOfWork.OrderRepository.GetAsync(x => x.TrackId == id, "OrderItems");
            return order;
        }

        public async Task<CommonBasketViewModel> DeleteProdFromBasket(int id)
        {
            if (!await AnyProd(id))
            {
                throw new ItemNotFoundException("Item not found");
            }

            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            if (appUser == null)
            {
                string cookie = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
                List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookie);
                }

                BasketCookieItemViewModel cookieItem = cookieItems.FirstOrDefault(x => x.ProductId == id);
                var product = await GetByIdAsync(id);

                if (cookieItem.Count >= 1)
                {
                    cookieItems.Remove(cookieItem);
                }

                cookie = JsonConvert.SerializeObject(cookieItems);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("basket", cookie);

                return await _getBasket(cookieItems);
            }
            else
            {
                BasketItem item = await _unitOfWork.BasketItemRepository.GetAsync(x => x.AppUserId == appUser.Id && x.ProductId == id);

                var product = await GetByIdAsync(id);

                if (product == null)
                {
                    throw new ItemNotFoundException("Item not found");
                }
                if (product.Count < item?.Count)
                {
                    throw new Exception();
                }

                if (item.Count >= 1)
                {
                    _unitOfWork.BasketItemRepository.Remove(item);
                }
                await _unitOfWork.CommitAsync();

                var items = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).ToList();
                return await _getBasket(items);
            }
        }

        public List<ProductListItemDto> ProductsForFilter(int? categoryid, int? brandid)
        {
            var query = _unitOfWork.ProductRepository.GetAll(x => !x.IsDeleted, "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "SSD.SSDCapacity", "Color", "Software");

            if (categoryid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.CategoryId == categoryid);
            }
            if (brandid != null && categoryid == null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.BrandId == brandid);
            }

            var products = query.ToList();

            var productDto = _mapper.Map<List<ProductListItemDto>>(products);

            return productDto;
        }
    }
}
