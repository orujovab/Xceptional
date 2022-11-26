using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class SSDCapacityService : ISSDCapacityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SSDCapacityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SSDCapacity> CreateAsync(SSDCapacity postDTO)
        {
            if (await _unitOfWork.SSDCapacityRepository.IsExistAsync(x => x.Capacity.ToLower().Trim() == postDTO.Capacity.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Capacity);
            }

            await _unitOfWork.SSDCapacityRepository.AddAsync(postDTO);
            await _unitOfWork.CommitAsync();

            return postDTO;
        }

        public async Task DeleteAsync(int id)
        {
            var existSerie = await _unitOfWork.SSDCapacityRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item Not Found");
            }

            _unitOfWork.SSDCapacityRepository.Remove(existSerie);
            _unitOfWork.Commit();
        }

        public PaginatedListDto<SSDCapacity> GetAllProd(int page)
        {
            var query = _unitOfWork.SSDCapacityRepository.GetAll();
            int pageSize = 3;

            List<SSDCapacity> items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var listDto = new PaginatedListDto<SSDCapacity>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<SSDCapacity> GetByIdAsync(int id)
        {
            var capacity = await _unitOfWork.SSDCapacityRepository.GetAsync(x => x.Id == id);

            if (capacity == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return capacity;
        }

        public async Task UpdateAsync(int id, SSDCapacity postDTO)
        {
            var existSerie = await _unitOfWork.SSDCapacityRepository.GetAsync(x => x.Id == id);

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
