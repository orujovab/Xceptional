using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IComp.Core.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        [StringLength(1000)]
        public string Url { get; set; }
        public byte Order { get; set; }
        public bool IsFirst { get; set; }
        public bool IsSecond { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
