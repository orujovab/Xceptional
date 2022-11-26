using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class ProcessorSerieService : IProcessorSerieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProcessorSerieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProcessorSerieGetDto> CreateAsync(ProcessorSeriePostDto postDTO)
        {
            if (await _unitOfWork.ProcessorSerieRepository.IsExistAsync(x => x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Name);
            }

            var procSerie = _mapper.Map<ProcessorSerie>(postDTO);
            await _unitOfWork.ProcessorSerieRepository.AddAsync(procSerie);
            await _unitOfWork.CommitAsync();

            return new ProcessorSerieGetDto
            {
                Id = procSerie.Id,
                Name = procSerie.Name,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var existSerie = await _unitOfWork.ProcessorSerieRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item Not Found");
            }

            _unitOfWork.ProcessorSerieRepository.Remove(existSerie);
            _unitOfWork.Commit();
        }

        public PaginatedListDto<ProcessorSerieListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.ProcessorSerieRepository.GetAll();
            int pageSize = 3;

            List<ProcessorSerieListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProcessorSerieListItemDto { Name = x.Name, Id = x.Id }).ToList();

            var listDto = new PaginatedListDto<ProcessorSerieListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<ProcessorSeriePostDto> GetByIdAsync(int id)
        {
            var procSerie = await _unitOfWork.ProcessorSerieRepository.GetAsync(x => x.Id == id);

            if (procSerie == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<ProcessorSeriePostDto>(procSerie);
        }

        public async Task UpdateAsync(int id, ProcessorSeriePostDto postDTO)
        {
            var existSerie = await _unitOfWork.ProcessorSerieRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }
            if (await _unitOfWork.ProcessorSerieRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Name);
            }

            existSerie.Name = postDTO.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
