using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        public bool? PosterStatus { get; set; }
        public Product Product { get; set; }
    }
}
