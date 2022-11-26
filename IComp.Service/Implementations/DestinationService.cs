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
    public class DestinationService : IDestinationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DestinationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Destination> CreateAsync(Destination destination)
        {
            if (await _unitOfWork.DestinationRepository.IsExistAsync(x => x.Name.ToLower().Trim() == destination.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + destination.Name);
            }

            await _unitOfWork.DestinationRepository.AddAsync(destination);
            await _unitOfWork.CommitAsync();

            return destination;
        }

        public async Task DeleteAsync(int id)
        {
            var destination = await _unitOfWork.DestinationRepository.GetAsync(x => x.Id == id);

            if (destination == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            _unitOfWork.DestinationRepository.Remove(destination);
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<Destination> GetAllProd(int page)
        {
            var query = _unitOfWork.DestinationRepository.GetAll();
            int pageSize = 3;

            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var listDto = new PaginatedListDto<Destination>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var destination = await _unitOfWork.DestinationRepository.GetAsync(x => x.Id == id);

            if (destination == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return destination;
        }

        public async Task UpdateAsync(int id, Destination destination)
        {
            var existDestination = await _unitOfWork.DestinationRepository.GetAsync(x => x.Id == id);

            if (existDestination == null)
            {
                throw new ItemNotFoundException("Item not found");
            }
            if (await _unitOfWork.DestinationRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == destination.Name.ToLower().Trim()))
            {
                throw new RecordDuplicatedException("Destination already exist with name " + destination.Name);
            }

            existDestination.Name = destination.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
