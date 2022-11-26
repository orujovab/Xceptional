using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class MemoryCapacityRepository : Repository<MemoryCapacity>, IMemoryCapacityRepository
    {
        public MemoryCapacityRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
