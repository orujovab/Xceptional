using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class ProcessorService : IProcessorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProcessorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProcessorGetDto> CreateAsync(ProcessorPostDTO postDTO)
        {
            if (await _unitOfWork.ProcessorRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.ProcessorSerieRepository.IsExistAsync(x => x.Id == postDTO.ProcessorSerieId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            Processor processor = _mapper.Map<Processor>(postDTO);
            
            await _unitOfWork.ProcessorRepository.AddAsync(processor);
            await _unitOfWork.CommitAsync();

            return new ProcessorGetDto
            {
                Id = processor.Id,
                ModelName = processor.ModelName
            };
        }

        public async Task DeleteAsync(int id)
        {
            var processor = await _unitOfWork.ProcessorRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            
            if (processor == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            processor.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<ProcessorListItemDto> GetAllProd(int page)
        {
            var query =  _unitOfWork.ProcessorRepository.GetAll();
            int pageSize = 3;

            List<ProcessorListItemDto> items = query.Skip((page - 1)* pageSize).Take(pageSize).Select(x => new ProcessorListItemDto { Id = x.Id, Model = x.ModelName, ProductsCount = x.Products.Count, IsDeleted = x.IsDeleted}).ToList();
            
            var listDto = new PaginatedListDto<ProcessorListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<ProcessorPostDTO> GetByIdAsync(int id)
        {
            var processor = await _unitOfWork.ProcessorRepository.GetAsync(x => x.Id == id);

            if (processor == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<ProcessorPostDTO>(processor);
        }

        public List<ProcessorSerieGetDto> GetProcSeries()
        {
            var procSeries = _unitOfWork.ProcessorSerieRepository.GetAll().ToList();

            var procSeriesDto = _mapper.Map<List<ProcessorSerieGetDto>>(procSeries);
            return procSeriesDto;
        }

        public async Task RestoreAsync(int id)
        {
            var processor = await _unitOfWork.ProcessorRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (processor == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            processor.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, ProcessorPostDTO postDTO)
        {
            var existProcessor = await _unitOfWork.ProcessorRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProcessor == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (await _unitOfWork.ProcessorRepository.IsExistAsync(x => x.Id!=id && x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.ProcessorSerieRepository.IsExistAsync(x => x.Id == postDTO.ProcessorSerieId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            existProcessor.ModelName = postDTO.ModelName;
            existProcessor.ProcessorSerieId = postDTO.ProcessorSerieId;
            existProcessor.CoreCount = postDTO.CoreCount;
            existProcessor.IsAvailable = postDTO.IsAvailable;
            existProcessor.Speed = postDTO.Speed;
            
            await _unitOfWork.CommitAsync();
        }
    }
}
