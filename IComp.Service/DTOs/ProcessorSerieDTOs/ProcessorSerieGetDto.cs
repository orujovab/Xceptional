using IComp.Service.DTOs.ProcessorDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.ProcessorSerieDTOs
{
    public class ProcessorSerieGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProcessorGetDto> Processors { get; set; }
    }
}
