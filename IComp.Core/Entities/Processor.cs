using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class Processor:BaseEntity
    {
        public int ProcessorSerieId { get; set; }
        public string ModelName { get; set; }
        public string Speed { get; set; }
        public int CoreCount { get; set; }
        public bool IsAvailable { get; set; }
        public ProcessorSerie ProcessorSerie { get; set; }
        public List<Product> Products { get; set; }
    }
}
