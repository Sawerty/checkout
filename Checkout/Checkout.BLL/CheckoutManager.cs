using Checkout.BLL.Interfaces;
using Checkout.DAO;
using System.Collections.Generic;

namespace Checkout.BLL
{
    public class CheckoutManager : ICheckoutManager
    {
        List<ShopingCart> scannedItems = new List<ShopingCart>();

        public List<ShopingCart> GetItems()
        {
           
            return scannedItems;
        }

        public void Scan(string sku)
        {
            scannedItems.Add(new ShopingCart
            {
                SKU = sku
            });
        }
    }
}
