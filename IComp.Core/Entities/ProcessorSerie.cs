using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class ProcessorSerie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Processor> Processors { get; set; }
    }
}
