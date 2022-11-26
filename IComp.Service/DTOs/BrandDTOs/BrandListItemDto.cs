using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.BrandDTOs
{
    public class BrandListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Image { get; set; }
        public int ProductsCount { get; set; }
        public bool IsPopular { get; set; }

        public bool IsDeleted { get; set; }
    }
}
