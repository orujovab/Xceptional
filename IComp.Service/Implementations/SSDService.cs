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
    public class SSDService : ISSDService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SSDService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SSD> CreateAsync(SSD postDTO)
        {
            if (await _unitOfWork.SSDRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.SSDCapacityRepository.IsExistAsync(x => x.Id == postDTO.SSDCapacityID))
            {
                throw new ItemNotFoundException("Item not found");
            }

            await _unitOfWork.SSDRepository.AddAsync(postDTO);
            await _unitOfWork.CommitAsync();

            return postDTO;
        }

        public async Task DeleteAsync(int id)
        {
            var hardDisc = await _unitOfWork.SSDRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (hardDisc == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            hardDisc.IsDeleted = true;
            hardDisc.IsAvailable = false;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<SSD> GetAllProd(int page)
        {
            var query = _unitOfWork.SSDRepository.GetAll("Products");
            int pageSize = 3;

            List<SSD> items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var listDto = new PaginatedListDto<SSD>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<SSD> GetByIdAsync(int id)
        {
            var hardDisc = await _unitOfWork.SSDRepository.GetAsync(x => x.Id == id);

            if (hardDisc == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<SSD>(hardDisc);
        }

        public List<SSDCapacity> GetCapacitiesForSSD()
        {
            var capacities = _unitOfWork.SSDCapacityRepository.GetAll().ToList();

            return capacities;
        }

        public async Task RestoreAsync(int id)
        {
            var hardDisc = await _unitOfWork.SSDRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (hardDisc == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            hardDisc.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, SSD postDTO)
        {
            var existProd = await _unitOfWork.SSDRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProd == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.SSDRepository.IsExistAsync(x => x.Id != id && x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.SSDCapacityRepository.IsExistAsync(x => x.Id == postDTO.SSDCapacityID))
            {
                throw new ItemNotFoundException("Item not found");
            }

            existProd.ModelName = postDTO.ModelName;
            existProd.SSDCapacityID = postDTO.SSDCapacityID;
            existProd.IsAvailable = postDTO.IsAvailable;

            await _unitOfWork.CommitAsync();
        }
    }
}
