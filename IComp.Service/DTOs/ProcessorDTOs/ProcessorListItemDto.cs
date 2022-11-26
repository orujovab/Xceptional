using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.ProcessorDTOs
{
    public class ProcessorListItemDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int ProductsCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
