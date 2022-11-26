using IComp.Core.Entities;
using IComp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IDestinationService
    {
        Task<Destination> CreateAsync(Destination destination);
        PaginatedListDto<Destination> GetAllProd(int page);
        Task UpdateAsync(int id, Destination destination);
        Task DeleteAsync(int id);
        Task<Destination> GetByIdAsync(int id);
    }
}
