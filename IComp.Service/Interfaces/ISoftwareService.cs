using IComp.Core.Entities;
using IComp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface ISoftwareService
    {
        Task<Software> CreateAsync(Software software);
        PaginatedListDto<Software> GetAllProd(int page);
        Task UpdateAsync(int id, Software software);
        Task DeleteAsync(int id);
        Task<Software> GetByIdAsync(int id);
    }
}
