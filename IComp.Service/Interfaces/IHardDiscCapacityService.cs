using IComp.Service.DTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IHardDiscCapacityService
    {
        Task<HardDiscCapacityGetDto> CreateAsync(HardDiscCapacityPostDto postDTO);
        PaginatedListDto<HardDiscCapacityListItemDto> GetAllProd(int page);
        Task UpdateAsync(int id, HardDiscCapacityPostDto postDTO);
        Task DeleteAsync(int id);
        Task<HardDiscCapacityPostDto> GetByIdAsync(int id);
    }
}
