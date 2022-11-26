using IComp.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.HardDiscDTOs
{
    public class HardDiscGetDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductGetDTO> Products { get; set; }
    }
}
