using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IFeedBackService
    {
        PaginatedListDto<FeedBack> GetAll(int page);
        Task UpdateAsync(FeedBack feedBackPost);
        Task<FeedBack> GetByIdAsync(int id);
    }
}
