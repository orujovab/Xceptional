using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface ISSDService
    {
        Task<SSD> CreateAsync(SSD postDTO);
        PaginatedListDto<SSD> GetAllProd(int page);
        List<SSDCapacity> GetCapacitiesForSSD();
        Task UpdateAsync(int id, SSD postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<SSD> GetByIdAsync(int id);
    }
}
