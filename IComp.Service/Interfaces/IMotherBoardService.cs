using IComp.Service.DTOs;
using IComp.Service.DTOs.MotherBoardDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IMotherBoardService 
    {
        Task<MotherBoardGetDto> CreateAsync(MotherBoardPostDto postDTO);
        PaginatedListDto<MotherBoardListItemDto> GetAllProd(int page);
        Task UpdateAsync(int id, MotherBoardPostDto postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<MotherBoardPostDto> GetByIdAsync(int id);
    }
}
