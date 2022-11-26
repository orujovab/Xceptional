using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class OrderItemRepository : Repository<OrderItem> , IOrderItemRepository
    {
        public OrderItemRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
