using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IBrandService
    {
        Task<BrandGetDto> CreateAsync(BrandPostDto postDTO);
        PaginatedListDto<BrandListItemDto> GetAllProd(int page);
        Task UpdateAsync(Brand existBrand, BrandPostDto postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<BrandPostDto> GetByIdAsync(int id);
        Task<Brand> GetBrandAsync(int id);

    }
}
