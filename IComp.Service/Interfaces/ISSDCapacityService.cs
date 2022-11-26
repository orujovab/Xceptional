using IComp.Core.Entities;
using IComp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface ISSDCapacityService
    {
        Task<SSDCapacity> CreateAsync(SSDCapacity postDTO);
        PaginatedListDto<SSDCapacity> GetAllProd(int page);
        Task UpdateAsync(int id, SSDCapacity postDTO);
        Task DeleteAsync(int id);
        Task<SSDCapacity> GetByIdAsync(int id);
    }
}
