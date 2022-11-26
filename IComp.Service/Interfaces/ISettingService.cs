using IComp.Core.Entities;
using IComp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface ISettingService
    {
        Task<Setting> CreateAsync(Setting setting);
        PaginatedListDto<Setting> GetAllProd(int page);
        Task UpdateAsync(int id, Setting setting);
        Task<Setting> GetByIdAsync(int id);

    }
}
