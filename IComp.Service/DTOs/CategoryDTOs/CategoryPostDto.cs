using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.CategoryDTOs
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
        public bool Collectable { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPopular { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
