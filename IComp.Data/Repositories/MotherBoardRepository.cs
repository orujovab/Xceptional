using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class MotherBoardRepository : Repository<MotherBoard>, IMotherBoardRepository
    {
        public MotherBoardRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
