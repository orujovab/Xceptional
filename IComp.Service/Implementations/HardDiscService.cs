using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class HardDiscService : IHardDiscService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HardDiscService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<HardDiscGetDto> CreateAsync(HardDiscPostDto postDTO)
        {
            if (await _unitOfWork.HardDiscRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.HardDiscCapacityRepository.IsExistAsync(x => x.Id == postDTO.HDDCapacityId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            HardDisc hardDisc = _mapper.Map<HardDisc>(postDTO);

            await _unitOfWork.HardDiscRepository.AddAsync(hardDisc);
            await _unitOfWork.CommitAsync();

            return new HardDiscGetDto
            {
                Id = hardDisc.Id,
                ModelName = hardDisc.ModelName
            };
        }

        public async Task DeleteAsync(int id)
        {
            var hardDisc = await _unitOfWork.HardDiscRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (hardDisc == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            hardDisc.IsDeleted = true;
            hardDisc.IsAvailable = false;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<HardDiscListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.HardDiscRepository.GetAll();
            int pageSize = 3;

            List<HardDiscListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new HardDiscListItemDto { Id = x.Id, ModelName = x.ModelName, ProductsCount = x.Products.Count, IsDeleted = x.IsDeleted }).ToList();

            var listDto = new PaginatedListDto<HardDiscListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<HardDiscPostDto> GetByIdAsync(int id)
        {
            var hardDisc = await _unitOfWork.HardDiscRepository.GetAsync(x => x.Id == id);

            if (hardDisc == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<HardDiscPostDto>(hardDisc);
        }

        public List<HardDiscCapacityGetDto> GetCapacitiesForHDD()
        {
            var capacities = _unitOfWork.HardDiscCapacityRepository.GetAll();

            var capacitiesDto = _mapper.Map<List<HardDiscCapacityGetDto>>(capacities);

            return capacitiesDto;
        }

        public async Task RestoreAsync(int id)
        {
            var hardDisc = await _unitOfWork.HardDiscRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (hardDisc == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            hardDisc.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, HardDiscPostDto postDTO)
        {
            var existProd = await _unitOfWork.HardDiscRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProd == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.HardDiscRepository.IsExistAsync(x => x.Id != id && x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.HardDiscCapacityRepository.IsExistAsync(x => x.Id == postDTO.HDDCapacityId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            existProd.ModelName = postDTO.ModelName;
            existProd.HDDCapacityId = postDTO.HDDCapacityId;
            existProd.IsAvailable = postDTO.IsAvailable;

            await _unitOfWork.CommitAsync();
        }
    }
}
