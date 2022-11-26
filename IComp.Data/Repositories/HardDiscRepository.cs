using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class HardDiscRepository : Repository<HardDisc>, IHardDiscRepository
    {
        public HardDiscRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
