using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class ProcessorSerieRepository : Repository<ProcessorSerie>, IProcessorSerieRepository
    {
        public ProcessorSerieRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
