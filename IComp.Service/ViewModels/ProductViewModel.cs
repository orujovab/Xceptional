using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.DTOs.DestinationDTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.DTOs.MotherBoardDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.DTOs.ProdTypeDTOs;
using IComp.Service.DTOs.ProductDTOs;
using IComp.Service.DTOs.SoftwareDTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using System.Collections.Generic;

namespace IComp.Service.ViewModels
{
    public class ProductViewModel
    {
        public PaginatedListDto<ProductListItemDto> Paginated { get; set; }
        public List<ProcessorSerieGetDto> processorSerieGetDtos { get; set; }
        public List<VCSerieGetDto> vCSerieGets { get; set; }
        public List<MotherBoardGetDto> motherBoardGetDtos { get; set; }
        public List<ProdTypeGetDto> prodTypeGetDtos { get; set; }
        public List<MCapacityGetDto> mCapacityGetDtos { get; set; }
        public List<BrandGetDto> brandGetDtos { get; set; }
        public List<DestinationGetDto> destinationGetDtos { get; set; }
        public List<HardDiscCapacityGetDto> hardDiscCapacityGetDtos { get; set; }
        public List<CategoryGetDto> categoryGetDtos { get; set; }
        public List<SSDCapacity> SSDCapacities { get; set; }
        public List<SoftwareGetDto> Softwares { get; set; }
        public Dictionary<string,string> Settings { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
    }
}
