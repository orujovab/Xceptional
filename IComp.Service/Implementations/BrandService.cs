using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BrandGetDto> CreateAsync(BrandPostDto postDTO)
        {
            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.Name);
            }

            Brand memory = _mapper.Map<Brand>(postDTO);

            await _unitOfWork.BrandRepository.AddAsync(memory);
            await _unitOfWork.CommitAsync();

            return new BrandGetDto
            {
                Id = memory.Id,
                Name = memory.Name
            };
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (brand == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            brand.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public async Task RestoreAsync(int id)
        {
            var brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (brand == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            brand.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<BrandListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.BrandRepository.GetAll();
            int pageSize = 3;

            List<BrandListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new BrandListItemDto { Id = x.Id, Name = x.Name, ProductsCount = x.Products.Count, IsDeleted = x.IsDeleted, Image = x.Image }).ToList();

            var listDto = new PaginatedListDto<BrandListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<BrandPostDto> GetByIdAsync(int id)
        {
            var brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id);

            if (brand == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<BrandPostDto>(brand);
        }

        public async Task UpdateAsync(Brand existProd, BrandPostDto postDTO)
        {

            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.Id != existProd.Id && x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.Name);
            }

            existProd.Name = postDTO.Name;
            existProd.IsPopular = postDTO.IsPopular;
            
            await _unitOfWork.CommitAsync();
        }
        public async Task<Brand> GetBrandAsync(int id)
        {
            var brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id==id && !x.IsDeleted);

            if (brand == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }

            return brand;
        }
    }
}
