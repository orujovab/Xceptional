using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class SSDCapacityRepository : Repository<SSDCapacity>, ISSDCapacityRepository
    {
        public SSDCapacityRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
