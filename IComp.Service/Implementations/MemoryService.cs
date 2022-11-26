using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.MemoryDTOs;
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
    public class MemoryService : IMemoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MemoryGetDto> CreateAsync(MemoryPostDto postDTO)
        {
            if (await _unitOfWork.MemoryRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.MemoryCapacityRepository.IsExistAsync(x => x.Id == postDTO.MemoryCapacityId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            ProdMemory memory = _mapper.Map<ProdMemory>(postDTO);

            await _unitOfWork.MemoryRepository.AddAsync(memory);
            await _unitOfWork.CommitAsync();

            return new MemoryGetDto
            {
                Id = memory.Id,
                ModelName = memory.ModelName
            };
        }

        public async Task DeleteAsync(int id)
        {
            var memory = await _unitOfWork.MemoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (memory == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            memory.IsDeleted = true;
            memory.IsAvailable = false;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<MemoryListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.MemoryRepository.GetAll();
            int pageSize = 3;

            List<MemoryListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new MemoryListItemDto { Id = x.Id, ModelName = x.ModelName, ProductsCount = x.Products.Count, IsDeleted = x.IsDeleted }).ToList();

            var listDto = new PaginatedListDto<MemoryListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<MemoryPostDto> GetByIdAsync(int id)
        {
            var memory = await _unitOfWork.MemoryRepository.GetAsync(x => x.Id == id);

            if (memory == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<MemoryPostDto>(memory);
        }

        public List<MCapacityGetDto> GetCapacities()
        {
            var procSeries = _unitOfWork.MemoryCapacityRepository.GetAll().ToList();

            var procSeriesDto = _mapper.Map<List<MCapacityGetDto>>(procSeries);
            return procSeriesDto;
        }

        public async Task RestoreAsync(int id)
        {
            var memory = await _unitOfWork.MemoryRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (memory == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            memory.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, MemoryPostDto postDTO)
        {
            var existProd = await _unitOfWork.MemoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProd == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.MemoryRepository.IsExistAsync(x => x.Id != id && x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.MemoryCapacityRepository.IsExistAsync(x => x.Id == postDTO.MemoryCapacityId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            existProd.ModelName = postDTO.ModelName;
            existProd.Price = postDTO.Price;
            existProd.MemoryCapacityId = postDTO.MemoryCapacityId;
            existProd.DDRType = postDTO.DDRType;
            existProd.Count = postDTO.Count;
            existProd.IsAvailable = postDTO.IsAvailable;
            existProd.Speed = postDTO.Speed;

            await _unitOfWork.CommitAsync();
        }
    }
}
