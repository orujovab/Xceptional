using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.MotherBoardDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class MotherBoardSevice : IMotherBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotherBoardSevice(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MotherBoardGetDto> CreateAsync(MotherBoardPostDto postDTO)
        {
            if (await _unitOfWork.MotherBoardRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            

            MotherBoard motherBoard = _mapper.Map<MotherBoard>(postDTO);

            await _unitOfWork.MotherBoardRepository.AddAsync(motherBoard);
            await _unitOfWork.CommitAsync();

            return new MotherBoardGetDto
            {
                Id = motherBoard.Id,
                ModelName = motherBoard.ModelName
            };
        }

        public async Task DeleteAsync(int id)
        {
            var motherBoard = await _unitOfWork.MotherBoardRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (motherBoard == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            motherBoard.IsDeleted = true;
            motherBoard.IsAvailable = false;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<MotherBoardListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.MotherBoardRepository.GetAll();
            int pageSize = 3;

            List<MotherBoardListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new MotherBoardListItemDto { Id = x.Id, ModelName = x.ModelName, ProductsCount = x.Products.Count, IsDeleted = x.IsDeleted }).ToList();

            var listDto = new PaginatedListDto<MotherBoardListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<MotherBoardPostDto> GetByIdAsync(int id)
        {
            var motherBoard = await _unitOfWork.MotherBoardRepository.GetAsync(x => x.Id == id);

            if (motherBoard == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<MotherBoardPostDto>(motherBoard);
        }

        public async Task RestoreAsync(int id)
        {
            var motherBoard = await _unitOfWork.MotherBoardRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (motherBoard == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            motherBoard.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, MotherBoardPostDto postDTO)
        {
            var existProd = await _unitOfWork.MotherBoardRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProd == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.MotherBoardRepository.IsExistAsync(x => x.Id != id && x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            

            existProd.ModelName = postDTO.ModelName;
            existProd.IsAvailable = postDTO.IsAvailable;

            await _unitOfWork.CommitAsync();
        }
    }
}
