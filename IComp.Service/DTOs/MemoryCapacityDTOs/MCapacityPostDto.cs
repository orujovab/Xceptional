using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Service.DTOs.MemoryCapacityDTOs
{
    public class MCapacityPostDto
    {
        [Required(ErrorMessage = "capacity is required")]
        [StringLength(maximumLength:50)]
        public string Capacity { get; set; }
    }
}
