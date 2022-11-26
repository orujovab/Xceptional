using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class MemoryCapacityService : IMemoryCapacityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemoryCapacityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MCapacityGetDto> CreateAsync(MCapacityPostDto postDTO)
        {
            if (await _unitOfWork.MemoryCapacityRepository.IsExistAsync(x => x.Capacity.ToLower().Trim() == postDTO.Capacity.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Capacity);
            }

            var capacity = _mapper.Map<MemoryCapacity>(postDTO);
            await _unitOfWork.MemoryCapacityRepository.AddAsync(capacity);
            await _unitOfWork.CommitAsync();

            return new MCapacityGetDto
            {
                Id = capacity.Id,
                Capacity = capacity.Capacity,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var existSerie = await _unitOfWork.MemoryCapacityRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item Not Found");
            }

            _unitOfWork.MemoryCapacityRepository.Remove(existSerie);
            _unitOfWork.Commit();
        }

        public PaginatedListDto<MCapacityListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.MemoryCapacityRepository.GetAll();
            int pageSize = 3;

            List<MCapacityListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new MCapacityListItemDto { Capacity = x.Capacity, Id = x.Id }).ToList();

            var listDto = new PaginatedListDto<MCapacityListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<MCapacityPostDto> GetByIdAsync(int id)
        {
            var capacity = await _unitOfWork.MemoryCapacityRepository.GetAsync(x => x.Id == id);

            if (capacity == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<MCapacityPostDto>(capacity);
        }

        public async Task UpdateAsync(int id, MCapacityPostDto postDTO)
        {
            var existSerie = await _unitOfWork.MemoryCapacityRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }
            if (await _unitOfWork.MemoryCapacityRepository.IsExistAsync(x => x.Id != id && x.Capacity.ToLower().Trim() == postDTO.Capacity.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Capacity);
            }

            existSerie.Capacity = postDTO.Capacity;
            await _unitOfWork.CommitAsync();
        }
    }
}
