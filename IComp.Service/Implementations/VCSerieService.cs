using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class VCSerieService : IVCSerieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VCSerieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<VCSerieGetDto> CreateAsync(VCSeriePostDto postDTO)
        {
            if (await _unitOfWork.VCSerieRepository.IsExistAsync(x => x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Name);
            }

            var vcSerie = _mapper.Map<VideoCardSerie>(postDTO);
            await _unitOfWork.VCSerieRepository.AddAsync(vcSerie);
            await _unitOfWork.CommitAsync();

            return new VCSerieGetDto
            {
                Id = vcSerie.Id,
                Name = vcSerie.Name,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var existSerie = await _unitOfWork.VCSerieRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item Not Found");
            }

            _unitOfWork.VCSerieRepository.Remove(existSerie);
            _unitOfWork.Commit();
        }

        public PaginatedListDto<VCSerieListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.VCSerieRepository.GetAll();
            int pageSize = 3;

            List<VCSerieListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new VCSerieListItemDto { Name = x.Name, Id = x.Id }).ToList();

            var listDto = new PaginatedListDto<VCSerieListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<VCSeriePostDto> GetByIdAsync(int id)
        {
            var procSerie = await _unitOfWork.VCSerieRepository.GetAsync(x => x.Id == id);

            if (procSerie == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<VCSeriePostDto>(procSerie);
        }

        public async Task UpdateAsync(int id, VCSeriePostDto postDTO)
        {
            var existSerie = await _unitOfWork.VCSerieRepository.GetAsync(x => x.Id == id);

            if (existSerie == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }
            if (await _unitOfWork.VCSerieRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Item already exist with name " + postDTO.Name);
            }

            existSerie.Name = postDTO.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
