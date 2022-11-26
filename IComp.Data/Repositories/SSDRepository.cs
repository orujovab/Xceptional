using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class SSDRepository : Repository<SSD>, ISSDRepository
    {
        public SSDRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
