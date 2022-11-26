using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class MotherBoard : BaseEntity
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string ModelName { get; set; }
        public bool IsAvailable { get; set; }
        public List<Product> Products { get; set; }
    }
}
