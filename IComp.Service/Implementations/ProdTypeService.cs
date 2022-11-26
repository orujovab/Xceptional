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
    public class ProdTypeService : IProdTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProdTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProdType> CreateAsync(ProdType prodType)
        {
            if (await _unitOfWork.ProdTypeRepository.IsExistAsync(x => x.Name.ToLower().Trim() == prodType.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + prodType.Name);
            }

            await _unitOfWork.ProdTypeRepository.AddAsync(prodType);
            await _unitOfWork.CommitAsync();

            return prodType;
        }

        public async Task DeleteAsync(int id)
        {
            var prodType = await _unitOfWork.ProdTypeRepository.GetAsync(x => x.Id == id);

            if (prodType == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            _unitOfWork.ProdTypeRepository.Remove(prodType);
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<ProdType> GetAllProd(int page)
        {
            var query = _unitOfWork.ProdTypeRepository.GetAll();
            int pageSize = 3;

            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var listDto = new PaginatedListDto<ProdType>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<ProdType> GetByIdAsync(int id)
        {
            var prodType = await _unitOfWork.ProdTypeRepository.GetAsync(x => x.Id == id);

            if (prodType == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return prodType;
        }

        public async Task UpdateAsync(int id, ProdType prodType)
        {
            var existProdType = await _unitOfWork.ProdTypeRepository.GetAsync(x => x.Id == id);

            if (existProdType == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (await _unitOfWork.ProdTypeRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == prodType.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + prodType.Name);
            }

            existProdType.Name = prodType.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
