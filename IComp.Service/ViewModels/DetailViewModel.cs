using IComp.Core.Entities;
using IComp.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.ViewModels
{
    public class DetailViewModel
    {
        public ProductGetDTO Product { get; set; }
        public ProductComment Comment { get; set; }
        public List<ProductGetDTO> RelatedProducts { get; set; }
        public List<ProductGetDTO> CheckedProducts { get; set; }
        public Dictionary<string,string> Settings { get; set; }
    }
}
