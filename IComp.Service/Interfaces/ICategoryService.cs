using IComp.Service.DTOs;
using IComp.Service.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryGetDto> CreateAsync(CategoryPostDto postDTO);
        PaginatedListDto<CategoryListItemDto> GetAllProd(int page);
        Task UpdateAsync(int id, CategoryPostDto postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<CategoryPostDto> GetByIdAsync(int id);
    }
}
