using IComp.Core.Entities;
using IComp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IOrderService
    {
        Task<PaginatedListDto<Order>> GetAll(int page);
        Task UpdateAsync(Order order);
        Task<Order> GetByIdAsync(int id);
        Task<decimal> GetTotalProfit();
        Task<decimal> GetTotalSales();
        Task<List<Order>> GetAllOrder();
    }
}
