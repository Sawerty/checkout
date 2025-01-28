﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.DAO
{
    public class SpecialPrice
    {
        public string SKU { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get { return Price / Quantity; } }
    }
}
