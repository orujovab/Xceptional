using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class VideoCardSerie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        public List<VideoCard> VideoCards { get; set; }
    }
}
