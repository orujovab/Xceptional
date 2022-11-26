using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
