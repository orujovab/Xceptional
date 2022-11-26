using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class SSD : BaseEntity
    {
        public int SSDCapacityID { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string ModelName { get; set; }
        public bool IsAvailable { get; set; }
        public SSDCapacity SSDCapacity { get; set; }
        public List<Product> Products { get; set; }
    }
}
