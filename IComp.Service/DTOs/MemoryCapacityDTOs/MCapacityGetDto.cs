using System;
using System.Collections.Generic;
using System.Text;
using IComp.Service.DTOs.MemoryDTOs;

namespace IComp.Service.DTOs.MemoryCapacityDTOs
{
    public class MCapacityGetDto
    {
        public int Id { get; set; }
        public string Capacity { get; set; }
        public List<MemoryGetDto> Memories { get; set; }
    }
}
