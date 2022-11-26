using IComp.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.ProcessorDTOs
{
    public class ProcessorGetDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductGetDTO> Products { get; set; }
    }
}
