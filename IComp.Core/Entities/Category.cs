using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IComp.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Collectable { get; set; }
        public bool IsPopular { get; set; }
        public List<Product> Products { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
