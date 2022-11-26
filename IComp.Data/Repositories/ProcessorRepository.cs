using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class ProcessorRepository : Repository<Processor>, IProcessorRepository
    {
        public ProcessorRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
