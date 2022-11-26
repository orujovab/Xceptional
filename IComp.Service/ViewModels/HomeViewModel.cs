using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.DTOs.ProductDTOs;
using System.Collections.Generic;

namespace IComp.Service.ViewModels
{
    public class HomeViewModel
    {
        public PaginatedListDto<ProductListItemDto> Paginated { get; set; }
        public List<BrandGetDto> Brands { get; set; }
        public List<CategoryGetDto> Categories { get; set; }
        public List<CategoryGetDto> PopularCategories { get; set; }
        public Dictionary<string,string> Settings { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
