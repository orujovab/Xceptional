using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class SoftWareRepository : Repository<Software>, ISoftWareRepository
    {
        public SoftWareRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
