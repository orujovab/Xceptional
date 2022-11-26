using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class CheckedProductsRepository : Repository<CheckedProducts>, ICheckedProductsRepository
    {
        public CheckedProductsRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
