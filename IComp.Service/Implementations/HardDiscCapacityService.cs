using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class HardDiscCapacityService : IHardDiscCapacityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HardDiscCapacityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<HardDiscCapacityGetDto> CreateAsync(HardDiscCapacityPostDto postDTO)
        {
            if (await _unitOfWork.HardDiscCapacityRepository.IsExistAsync(x => x.Capacity.ToLower().Trim() == postDTO.Capacity.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Capacity);
            }

            var capacity = _mapper.Map<HDDCapacity>(postDTO);
            await _unitOfWork.HardDiscCapacityRepository.AddAsync(capacity);
            await _unitOfWork.CommitAsync();

            return new HardDiscCapacityGetDto
            {
                Id = capacity.Id,
                Capacity = capacity.Capacity,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var existSerie = await _unitOfWork.HardDiscCapacityRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item Not Found");
            }

            _unitOfWork.HardDiscCapacityRepository.Remove(existSerie);
            _unitOfWork.Commit();
        }

        public PaginatedListDto<HardDiscCapacityListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.HardDiscCapacityRepository.GetAll();
            int pageSize = 3;

            List<HardDiscCapacityListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new HardDiscCapacityListItemDto { Capacity = x.Capacity, Id = x.Id }).ToList();

            var listDto = new PaginatedListDto<HardDiscCapacityListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<HardDiscCapacityPostDto> GetByIdAsync(int id)
        {
            var capacity = await _unitOfWork.HardDiscCapacityRepository.GetAsync(x => x.Id == id);

            if (capacity == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<HardDiscCapacityPostDto>(capacity);
        }

        public async Task UpdateAsync(int id, HardDiscCapacityPostDto postDTO)
        {
            var existSerie = await _unitOfWork.HardDiscCapacityRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }
            if (await _unitOfWork.HardDiscCapacityRepository.IsExistAsync(x => x.Id != id && x.Capacity.ToLower().Trim() == postDTO.Capacity.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Capacity);
            }
            existSerie.Capacity = postDTO.Capacity;
            existSerie.CycleRate = postDTO.CycleRate;
            await _unitOfWork.CommitAsync();
        }
    }
}
