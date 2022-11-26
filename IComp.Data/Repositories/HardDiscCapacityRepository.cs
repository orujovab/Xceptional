using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class HardDiscCapacityRepository : Repository<HDDCapacity>, IHardDiscCapacityRepository
    {
        public HardDiscCapacityRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
