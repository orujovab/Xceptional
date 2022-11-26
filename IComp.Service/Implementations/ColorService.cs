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
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Color> CreateAsync(Color color)
        {
            if (await _unitOfWork.ColorRepository.IsExistAsync(x => x.Name.ToLower().Trim() == color.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + color.Name);
            }

            await _unitOfWork.ColorRepository.AddAsync(color);
            await _unitOfWork.CommitAsync();

            return color;
        }

        public async Task DeleteAsync(int id)
        {
            var color = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == id);

            if (color == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            _unitOfWork.ColorRepository.Remove(color);
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<Color> GetAllProd(int page)
        {
            var query = _unitOfWork.ColorRepository.GetAll();
            int pageSize = 3;

            List<Color> items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var listDto = new PaginatedListDto<Color>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            var color = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == id);

            if (color == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return color;
        }

        public async Task UpdateAsync(int id, Color color)
        {
            var existColor = await _unitOfWork.ColorRepository.GetAsync(x => x.Id == id);

            if (existColor == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (await _unitOfWork.ColorRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == color.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + color.Name);
            }

            existColor.Name = color.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
