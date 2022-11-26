using IComp.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Service.DTOs.ProductPartsDTOs
{
    public class ProdRamDto
    {
        public int ProdTypeId { get; set; }
        public int BrandId { get; set; }
        public int DestinationId { get; set; }
        public int CategoryId { get; set; }
        public int ProdMemoryId { get; set; }
        public int ColorId { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string WarrantyPeriod { get; set; }
        [Required]

        public decimal SalePrice { get; set; }
        [Required]

        public decimal CostPrice { get; set; }
        [Required]

        public decimal DiscountPercent { get; set; }

        public Color Color { get; set; }
        public ProdMemory ProdMemory { get; set; }
        public Category Category { get; set; }
        public ProdType ProdType { get; set; }
        public Brand Brand { get; set; }
        public Destination Destination { get; set; }

        public IFormFile PosterFile { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
