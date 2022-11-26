using IComp.Service.DTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IHardDiscService
    {
        Task<HardDiscGetDto> CreateAsync(HardDiscPostDto postDTO);
        PaginatedListDto<HardDiscListItemDto> GetAllProd(int page);
        List<HardDiscCapacityGetDto> GetCapacitiesForHDD();
        Task UpdateAsync(int id, HardDiscPostDto postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<HardDiscPostDto> GetByIdAsync(int id);
    }
}
