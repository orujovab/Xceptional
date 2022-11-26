﻿using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class VCSerieRepository : Repository<VideoCardSerie>, IVCSerieRepository
    {
        public VCSerieRepository(StoreDbContext context ) : base( context )
        {

        }
    }
}
