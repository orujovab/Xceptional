using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.BrandDTOs
{
    public class BrandPostDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsPopular { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
