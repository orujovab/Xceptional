using IComp.Core.Entities;
using IComp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IColorService
    {
        Task<Color> CreateAsync(Color color);
        PaginatedListDto<Color> GetAllProd(int page);
        Task UpdateAsync(int id, Color colo);
        Task DeleteAsync(int id);
        Task<Color> GetByIdAsync(int id);
    }
}
