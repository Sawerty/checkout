using System;
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
        //This wasn't defined clearly in the documentation.
        //The example say 3 for 130, but does not define 4 would be also discounted as 3 items for 130 and 1 item for 50, I assume we define the minimum qty to reach the discounted price.
        public decimal DiscountedPrice { get { return Price / Quantity; } }
    }
}
