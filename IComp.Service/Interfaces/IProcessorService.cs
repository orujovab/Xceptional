using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IProcessorService
    {
        Task<ProcessorGetDto> CreateAsync(ProcessorPostDTO postDTO);
        PaginatedListDto<ProcessorListItemDto> GetAllProd(int page);
        List<ProcessorSerieGetDto> GetProcSeries();
        Task UpdateAsync(int id, ProcessorPostDTO postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<ProcessorPostDTO> GetByIdAsync(int id);
    }

}
