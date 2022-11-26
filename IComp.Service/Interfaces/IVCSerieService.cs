using IComp.Service.DTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IVCSerieService
    {
        Task<VCSerieGetDto> CreateAsync(VCSeriePostDto postDTO);
        PaginatedListDto<VCSerieListItemDto> GetAllProd(int page);
        Task UpdateAsync(int id, VCSeriePostDto postDTO);
        Task DeleteAsync(int id);
        Task<VCSeriePostDto> GetByIdAsync(int id);
    }
}
