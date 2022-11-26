using IComp.Service.DTOs;
using IComp.Service.DTOs.MemoryDTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IMemoryService
    {
        Task<MemoryGetDto> CreateAsync(MemoryPostDto postDTO);
        PaginatedListDto<MemoryListItemDto> GetAllProd(int page);
        List<MCapacityGetDto> GetCapacities();
        Task UpdateAsync(int id, MemoryPostDto postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<MemoryPostDto> GetByIdAsync(int id);
    }
}
