using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Service.DTOs.VCSerieDTOs
{
    public class VCSeriePostDto
    {
        [Required(ErrorMessage = "seriename is required")]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
    }
}
