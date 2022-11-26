using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class SSDCapacity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Capacity { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string CycleRate { get; set; }
        public List<SSD> SSDs { get; set; }
    }
}
