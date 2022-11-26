using IComp.Core.Entities;
using IComp.Service.DTOs.CategoryDTOs;
using System.Collections.Generic;

namespace IComp.Areas.ViewModels
{
    public class DashboardViewModel
    {
        public decimal TotalProfit { get; set; }
        public decimal TotalSales { get; set; }
        public int NewCostumer { get; set; }
        public int OrderCount { get; set; }
        public int AcceptedOrders { get; set; }
        public int PendingOrders { get; set; }
        public int RejectedOrders { get; set; }
        public int CanceledOrders { get; set; }
        public List<Order> Orders { get; set; }
        public List<CategoryGetDto> Categories { get; set; }
    }
}
