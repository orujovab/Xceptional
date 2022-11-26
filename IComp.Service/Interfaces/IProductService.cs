using IComp.Core.Entities;
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
using IComp.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductGetDTO> CreateAsync(ProductPostDto postDTO);
        PaginatedListDto<ProductListItemDto> GetAllProd(int? value, int page);
        PaginatedListDto<ProductListItemDto> GetAllProdWithFilter(int page);
        Task<PaginatedListDto<ProductListItemDto>> FilterProd(decimal? minprice, decimal? maxprice, string sort, int? softwareid , int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? prodmemoryid, int? brandid, int? destinationid, int? harddiscid, int? ssdcapacityid, int? categoryid, int page);
        List<ProductListItemDto> ProductsForFilter(int? categoryid, int? brandid);
        decimal FilterByPrice(string val);
        Task<DetailViewModel> FindByIdAsync(int id);
        List<ColorGetDto> GetColors();
        List<SoftwareGetDto> GetSoftwares();
        List<ProcessorGetDto> GetProcessors();
        List<CategoryGetDto> GetCategories();
        List<BrandGetDto> GetBrands();
        List<HardDiscGetDto> GetHardDiscs();
        List<SSD> GetSSDs();
        List<MemoryGetDto> GetMemories();
        List<MotherBoardGetDto> GetMotherBoards();
        List<VideoCardGetDto> GetVideoCards();
        List<ProdTypeGetDto> GetProdTypes();
        List<DestinationGetDto> GetDestinations();
        List<ProcessorSerieGetDto> GetProcessirSeries();
        List<HardDiscCapacityGetDto> GetHardDiscCapacities();
        List<SSDCapacity> GetSSDCapacities();
        List<MCapacityGetDto> GetMemoryCapacities();
        List<VCSerieGetDto> GetVideoCardSeries();
        List<Slider> GetSlider();
        Dictionary<string, string> GetSettings();

        Task UpdateAsync(int id, ProductPostDto exisProduct);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<ProductPostDto> GetByIdAsync(int id);
        Task<ProductImage> GetProductImage(int id);
        Task DeleteProductImage(ProductImage productImage);

        Task<CommonBasketViewModel> _getBasket(List<BasketCookieItemViewModel> basketItems);
        Task<CommonBasketViewModel> _getBasket(List<BasketItem> cardItems);
        Task<bool> AnyProd(int id);
        Task<List<BasketItem>> UserBasket(int id, AppUser appUser);
        Task<CommonBasketViewModel> DeleteBasket(int id);
        Task<CommonBasketViewModel> DeleteProdFromBasket(int id);

        Task<List<Product>> SearchProd(string searchString, int? maxProdCount);
        Task<PaginatedListDto<ProductGetDTO>> SearchProdAll(string searchString, int page);

        Task<int> Comment(ProductComment comment);
        Task<FastCheckOutViewModel> FastOrder(int id);
        Task CreateOrder(int id, Order order, int prodcount, int ordercount);

        Task<CheckOutViewModel> CheckOut();
        Task CreateOrder(Order order);
        Task<CommonBasketViewModel> GetBasketItems(AppUser appUser);
        Task<List<Order>> GetOrdersAsync(AppUser appUser);
        Task<Order> GetOrderByIdAsync(string id);


    }
}
