using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.ViewModels
{
    public class ProfileViewModel
    {
        public UserUpdateViewModel UserUpdate { get; set; }
        public List<Order> Orders { get; set; }
    }
}
