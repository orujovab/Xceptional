using System;
using System.Collections.Generic;
using System.Text;
using IComp.Service.DTOs.VideoCardDTOs;

namespace IComp.Service.DTOs.VCSerieDTOs
{
    public class VCSerieGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VideoCardGetDto> VideoCards { get; set; }
    }
}
