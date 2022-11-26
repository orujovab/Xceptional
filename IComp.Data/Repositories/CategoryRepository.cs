using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
