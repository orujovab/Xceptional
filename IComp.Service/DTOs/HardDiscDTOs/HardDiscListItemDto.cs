using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.HardDiscDTOs
{
    public class HardDiscListItemDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int ProductsCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
