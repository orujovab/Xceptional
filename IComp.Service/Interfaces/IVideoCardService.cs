using IComp.Service.DTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.DTOs.VideoCardDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IVideoCardService
    {
        Task<VideoCardGetDto> CreateAsync(VideoCardPostDto postDTO);
        PaginatedListDto<VideoCardListItemDto> GetAllProd(int page);
        List<VCSerieGetDto> GetVCSeries();
        Task UpdateAsync(int id, VideoCardPostDto postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<VideoCardPostDto> GetByIdAsync(int id);
    }
}
