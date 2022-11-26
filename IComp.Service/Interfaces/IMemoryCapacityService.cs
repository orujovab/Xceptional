using IComp.Service.DTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IMemoryCapacityService
    {
        Task<MCapacityGetDto> CreateAsync(MCapacityPostDto postDTO);
        PaginatedListDto<MCapacityListItemDto> GetAllProd(int page);
        Task UpdateAsync(int id, MCapacityPostDto postDTO);
        Task DeleteAsync(int id);
        Task<MCapacityPostDto> GetByIdAsync(int id);
    }
}
