using System.Collections.Generic;

namespace IComp.Service.ViewModels
{
    public class CommonBasketViewModel
    {
        public List<BasketProductViewModel> BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
