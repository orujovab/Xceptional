using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class VideoCard : BaseEntity
    {
        public int VideoCardSerieId { get; set; }
        public string ModelName { get; set; }
        public bool IsAvailable { get; set; }
        public string MemoryCapacity { get; set; }
        public string CoreSpeed { get; set; }
        public VideoCardSerie VideoCardSerie { get; set; }
        public List<Product> Products { get; set; }
    }
}
