using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class FeedBackRepository : Repository<FeedBack>, IFeedBackRepository
    {
        public FeedBackRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
