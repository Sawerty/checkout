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

        public ShopingCart GetItem(string sku)
        {

            return scannedItems.Where(x=>x.SKU==sku).FirstOrDefault();
        }

        public void Scan(string sku)
        {
            if (masterItems.Count > 0)
            {
                ItemMaster scannedItemMaster = masterItems.Where(x => x.SKU == sku).FirstOrDefault();
                if (scannedItemMaster != null)
                {
                    ShopingCart scannedItem = scannedItems.Where(x => x.SKU == sku).FirstOrDefault();


                    if (scannedItem != null)
                    {
                        scannedItem.Quantity++;
                        scannedItem.LineTotal = scannedItem.LineTotal + scannedItemMaster.UnitPrice;
                    }
                    else
                    {
                        scannedItems.Add(new ShopingCart
                        {
                            SKU = sku,
                            Quantity = 1,
                            LineTotal= scannedItemMaster.UnitPrice
                        });
                    }
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

        public decimal GetTotalPrice()
        {
            decimal totalPrice = scannedItems.Sum(x => x.LineTotal);

            return totalPrice;
        }
    }
}
