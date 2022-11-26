using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class CheckedProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
