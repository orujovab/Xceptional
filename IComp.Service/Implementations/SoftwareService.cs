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
    public class SoftwareService : ISoftwareService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SoftwareService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Software> CreateAsync(Software software)
        {
            if (await _unitOfWork.SoftWareRepository.IsExistAsync(x => x.Name.ToLower().Trim() == software.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + software.Name);
            }

            await _unitOfWork.SoftWareRepository.AddAsync(software);
            await _unitOfWork.CommitAsync();

            return software;
        }

        public async Task DeleteAsync(int id)
        {
            var software = await _unitOfWork.SoftWareRepository.GetAsync(x => x.Id == id);

            if (software == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            _unitOfWork.SoftWareRepository.Remove(software);
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<Software> GetAllProd(int page)
        {
            var query = _unitOfWork.SoftWareRepository.GetAll();
            int pageSize = 3;

            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var listDto = new PaginatedListDto<Software>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<Software> GetByIdAsync(int id)
        {
            var prodType = await _unitOfWork.SoftWareRepository.GetAsync(x => x.Id == id);

            if (prodType == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return prodType;
        }

        public async Task UpdateAsync(int id, Software software)
        {
            var existSoftware = await _unitOfWork.SoftWareRepository.GetAsync(x => x.Id == id);

            if (existSoftware == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (await _unitOfWork.ProdTypeRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == software.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + software.Name);
            }

            existSoftware.Name = software.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
