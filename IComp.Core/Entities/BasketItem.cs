﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        public DateTime CreatedAt { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
