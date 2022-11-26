using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class MemoryRepository : Repository<ProdMemory>, IMemoryRepository
    {
        public MemoryRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
