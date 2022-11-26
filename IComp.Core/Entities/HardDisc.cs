using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class HardDisc : BaseEntity
    {
        public int HDDCapacityId { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string ModelName { get; set; }
        public bool IsAvailable { get; set; }
        public HDDCapacity HDDCapacity { get; set; }
        public List<Product> Products { get; set; }
    }
}
