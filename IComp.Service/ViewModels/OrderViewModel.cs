using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<BasketProductViewModel> Product { get; set; }
    }
}
