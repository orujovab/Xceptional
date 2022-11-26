using IComp.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.SoftwareDTOs
{
    public class SoftwareGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductGetDTO> Products { get; set; }
    }
}
