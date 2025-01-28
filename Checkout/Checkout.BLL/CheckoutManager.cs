using Checkout.BLL.Interfaces;
using Checkout.DAO;
using System.Collections.Generic;

namespace Checkout.BLL
{
    public class CheckoutManager : ICheckoutManager
    {
        public List<ShopingCart> GetItems()
        {
            List<ShopingCart> scannedItems = new List<ShopingCart>(); 
            return scannedItems;
        }

        public void Scan(string sku)
        {
           
        }
    }
}
