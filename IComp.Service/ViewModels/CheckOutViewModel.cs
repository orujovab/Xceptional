using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.ViewModels
{
    public class CheckOutViewModel
    {
        public CommonBasketViewModel Basket { get; set; }
        public Order Order { get; set; }
    }
}
