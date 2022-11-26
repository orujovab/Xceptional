using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        public SettingRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
