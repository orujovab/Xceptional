using IComp.Core.Entities;
using IComp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IProdTypeService
    {
        Task<ProdType> CreateAsync(ProdType prodType);
        PaginatedListDto<ProdType> GetAllProd(int page);
        Task UpdateAsync(int id, ProdType prodType);
        Task DeleteAsync(int id);
        Task<ProdType> GetByIdAsync(int id);
    }
}
