using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.DTOs.VideoCardDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class VideoCardService : IVideoCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VideoCardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<VideoCardGetDto> CreateAsync(VideoCardPostDto postDTO)
        {
            if (await _unitOfWork.VideoCardRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.VCSerieRepository.IsExistAsync(x => x.Id == postDTO.VideoCardSerieId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            VideoCard videoCard = _mapper.Map<VideoCard>(postDTO);

            await _unitOfWork.VideoCardRepository.AddAsync(videoCard);
            await _unitOfWork.CommitAsync();

            return new VideoCardGetDto
            {
                Id = videoCard.Id,
                ModelName = videoCard.ModelName
            };
        }

        public async Task DeleteAsync(int id)
        {
            var videoCard = await _unitOfWork.VideoCardRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (videoCard == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            videoCard.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<VideoCardListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.VideoCardRepository.GetAll();
            int pageSize = 3;

            List<VideoCardListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new VideoCardListItemDto { Id = x.Id, ModelName = x.ModelName, ProductsCount = x.Products.Count, IsDeleted = x.IsDeleted }).ToList();

            var listDto = new PaginatedListDto<VideoCardListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<VideoCardPostDto> GetByIdAsync(int id)
        {
            var videoCard = await _unitOfWork.VideoCardRepository.GetAsync(x => x.Id == id);

            if (videoCard == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            var postDto = _mapper.Map<VideoCardPostDto>(videoCard);

            return postDto;
        }
        public List<VCSerieGetDto> GetVCSeries()
        {
            var vcSeries = _unitOfWork.VCSerieRepository.GetAll().ToList();

            var vcSeriesDto = _mapper.Map<List<VCSerieGetDto>>(vcSeries);
            return vcSeriesDto;
        }

        public async Task RestoreAsync(int id)
        {
            var videoCard = await _unitOfWork.VideoCardRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (videoCard == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            videoCard.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, VideoCardPostDto postDTO)
        {
            var existVC = await _unitOfWork.VideoCardRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existVC == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (await _unitOfWork.VideoCardRepository.IsExistAsync(x => x.Id!=id && x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.VCSerieRepository.IsExistAsync(x => x.Id == postDTO.VideoCardSerieId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            existVC.ModelName = postDTO.ModelName;
            existVC.VideoCardSerieId = postDTO.VideoCardSerieId;
            existVC.IsAvailable = postDTO.IsAvailable;
            existVC.CoreSpeed = postDTO.CoreSpeed;
            existVC.MemoryCapacity = postDTO.MemoryCapacity;
            
            await _unitOfWork.CommitAsync();
        }
    }
}
