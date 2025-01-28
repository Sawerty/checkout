using Checkout.BLL.Interfaces;
using Checkout.DAO;
using System.Collections.Generic;

namespace Checkout.BLL
{
    public class CheckoutManager : ICheckoutManager
    {
        private List<ShopingCart> scannedItems = new List<ShopingCart>();
        private List<ItemMaster> masterItems = new List<ItemMaster>();

        public CheckoutManager()
        {
            GenerateTestItems generateTestItems = new GenerateTestItems();
            masterItems= generateTestItems.GetItemMaster();
        }

        public List<ShopingCart> GetItems()
        {
           
            return scannedItems;
        }

        public void Scan(string sku)
        {
            if (masterItems.Count > 0)
            {

                if (masterItems.Where(x => x.SKU == sku).FirstOrDefault() != null)
                {
                    scannedItems.Add(new ShopingCart
                    {
                        SKU = sku
                    });
                }
                else
                {
                    throw new ArgumentException("Item is not found!");
                }
            }
            else
            {
                throw new Exception("No Item Master found!");
            }
        }
    }
}
