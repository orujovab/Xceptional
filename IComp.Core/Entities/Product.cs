using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IComp.Core.Entities
{
    public class Product : BaseEntity
    {
        public int? ProcessorId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int DestinationId { get; set; }
        public int? HardDiscId { get; set; }
        public int? SSDId { get; set; }
        public int? ProdMemoryId { get; set; }
        public int? MotherBoardId { get; set; }
        public int ProdTypeId { get; set; }
        public int? VideoCardId { get; set; }
        public int? ColorId { get; set; }
        public int? SoftwareId { get; set; }

        [Required]
        [StringLength(maximumLength:500)]
        public string Name { get; set; }

        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }

        public int Count { get; set; }
        [Range(1,5)]
        public int? Rate { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPopular { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasWifi { get; set; }

        [StringLength(maximumLength:500)]
        public string SoundType { get; set; }
        [StringLength(maximumLength: 500)]

        public string InputPorts { get; set; }
        [StringLength(maximumLength: 500)]

        public string USB { get; set; }
        [StringLength(maximumLength: 500)]

        public string USBTypeC { get; set; }
        [StringLength(maximumLength: 500)]

        public string Network { get; set; }
        [StringLength(maximumLength: 500)]

        public string PowerSupply { get; set; }
        [StringLength(maximumLength: 500)]

        public string Weight { get; set; }
        [StringLength(maximumLength: 500)]

        public string WarrantyPeriod { get; set; }


        [StringLength(maximumLength: 500)]

        public string Speed { get; set; }

        public Processor Processor { get; set; }
        public VideoCard VideoCard { get; set; }
        public MotherBoard MotherBoard { get; set; }
        public ProdType ProdType { get; set; }
        public ProdMemory ProdMemory { get; set; }
        public Brand Brand { get; set; }
        public Destination Destination { get; set; }
        public HardDisc HardDisc { get; set; }
        public SSD SSD { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Software Software { get; set; }
        [NotMapped]
        public IFormFile PosterFile { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public List<int> FileIds { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductComment> ProductComments { get; set; }
    }
}
