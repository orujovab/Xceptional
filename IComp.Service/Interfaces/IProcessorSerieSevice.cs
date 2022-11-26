using IComp.Service.DTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IProcessorSerieService
    {
        Task<ProcessorSerieGetDto> CreateAsync(ProcessorSeriePostDto postDTO);
        PaginatedListDto<ProcessorSerieListItemDto> GetAllProd(int page);
        Task UpdateAsync(int id, ProcessorSeriePostDto postDTO);
        Task DeleteAsync(int id);
        Task<ProcessorSeriePostDto> GetByIdAsync(int id);

    }
}
