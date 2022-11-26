using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.MemoryDTOs
{
    public class MemoryGetDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsDeleted { get; set; }

        public List<Product> Products { get; set; }
    }
}
