using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class MemoryCapacity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Capacity { get; set; }
        public List<ProdMemory> Memories { get; set; }
    }
}
