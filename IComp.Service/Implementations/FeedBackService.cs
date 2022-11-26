using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedBackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PaginatedListDto<FeedBack> GetAll(int page)
        {
            var query = _unitOfWork.FeedBackRepository.GetAll();
            int pageSize = 3;
            var listDto = new PaginatedListDto<FeedBack>(query.ToList(), query.Count(), page, pageSize);
            return listDto;
        }

        public async Task<FeedBack> GetByIdAsync(int id)
        {
            var feedBack = await _unitOfWork.FeedBackRepository.GetAsync(x => x.Id == id);

            if (feedBack == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return feedBack;
        }

        public async Task UpdateAsync(FeedBack feedBackPost)
        {
            var feedBack = await GetByIdAsync(feedBackPost.Id);

            if (String.IsNullOrWhiteSpace(feedBackPost.Answer))
            {
                return;
            }

            feedBack.Answer = feedBackPost.Answer;
            feedBack.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }
    }
}
