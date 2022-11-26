using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class ProdTypeRepository : Repository<ProdType>, IProdTypeRepository
    {
        public ProdTypeRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
