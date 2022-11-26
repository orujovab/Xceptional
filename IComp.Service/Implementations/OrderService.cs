using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public OrderService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<PaginatedListDto<Order>> GetAll(int page)
        {
            var query = _unitOfWork.OrderRepository.GetAll();
            int pageSize = 3;

            List<Order> items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var listDto = new PaginatedListDto<Order>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            var orders = _unitOfWork.OrderRepository.GetAll("OrderItems");
            return await orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var existOrder = await _unitOfWork.OrderRepository.GetAsync(x => x.Id == id);
            if (existOrder == null) { throw new ItemNotFoundException("Item not found"); }
            return existOrder;
        }

        public async Task<decimal> GetTotalProfit()
        {
            var orderItems = _unitOfWork.OrderItemRepository.GetAll("Order");
            orderItems = orderItems.Where(x => ((int)x.Order.Status) != 1 && ((int)x.Order.Status) != 3 && ((int)x.Order.Status) != 4);
            var totalSale = await orderItems.SumAsync(x => x.SalePrice);
            var totalCost = await orderItems.SumAsync(x => x.CostPrice);

            var totalProfit = totalSale - totalCost;
            totalProfit = totalProfit * 0.59m;
            return totalProfit;
        }

        public async Task<decimal> GetTotalSales()
        {
            var orderItems = _unitOfWork.OrderItemRepository.GetAll("Order");
            orderItems = orderItems.Where(x => ((int)x.Order.Status) != 1 && ((int)x.Order.Status) != 3 && ((int)x.Order.Status) != 4);
            var totalSale = await orderItems.SumAsync(x => x.SalePrice);

            totalSale = totalSale * 0.59m;
            return totalSale;
        }

        public async Task UpdateAsync(Order order)
        {
            var existOrder = await GetByIdAsync(order.Id);
            existOrder.Status = order.Status;
            await _unitOfWork.CommitAsync();
        }
    }
}
