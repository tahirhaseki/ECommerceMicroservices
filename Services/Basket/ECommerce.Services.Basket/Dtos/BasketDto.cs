﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services.Basket.Dtos
{
    public class BasketDto
    {
        public string userId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { 
            get => BasketItems.Sum(x => x.Price * x.Quantity); 
        }
    }
}
