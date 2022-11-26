using IComp.Service.DTOs.HardDiscDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.HardDiscCapacityDTOs
{
    public class HardDiscCapacityGetDto
    {
        public int Id { get; set; }
        public string Capacity { get; set; }
        public string CycleRate { get; set; }
        public bool IsSSD { get; set; }
        public bool IsHDD { get; set; }
        public List<HardDiscGetDto> HardDiscs { get; set; }
    }
}
