using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class ProductComment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AppUserId { get; set; }

        [Range(1, 5)]
        public byte Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(maximumLength: 300)]
        public string Name { get; set; }
        [StringLength(maximumLength: 300)]
        public string Text { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
