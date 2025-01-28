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

        public ItemMaster GetItemMasterData(string sku)
        {

            return masterItems.Where(x => x.SKU == sku).FirstOrDefault();
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
       
                    }
                    else
                    {
                        scannedItems.Add(new ShopingCart
                        {
                            SKU = sku,
                            Quantity = 1
                           
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
            //set shoping cart price here, because of the frequent changes
            foreach (ShopingCart scannedItem in scannedItems)
            {
                ItemMaster scannedItemMaster = masterItems.Where(x => x.SKU == scannedItem.SKU).FirstOrDefault();
                scannedItem.LineTotal = scannedItem.Quantity * scannedItemMaster.UnitPrice;

            }

            decimal totalPrice = scannedItems.Sum(x => x.LineTotal);

            return totalPrice;
        }
    }
}
