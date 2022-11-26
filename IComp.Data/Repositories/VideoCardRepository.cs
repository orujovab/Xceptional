using IComp.Core.Entities;
using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Repositories
{
    public class VideoCardRepository : Repository<VideoCard>, IVideoCardRepository
    {
        public VideoCardRepository(StoreDbContext context) : base(context)
        {

        }
    }
}
