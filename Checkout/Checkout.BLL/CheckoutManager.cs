﻿using Checkout.BLL.Interfaces;
using Checkout.DAO;
using System.Collections.Generic;

namespace Checkout.BLL
{
    public class CheckoutManager : ICheckoutManager
    {
        private List<ShopingCart> scannedItems = new List<ShopingCart>();
        private List<ItemMaster> masterItems = new List<ItemMaster>();
        private List<SpecialPrice> specialPrices = new List<SpecialPrice>();

        public CheckoutManager()
        {
            GenerateTestItems generateTestItems = new GenerateTestItems();
            masterItems= generateTestItems.GetItemMaster();
            specialPrices = generateTestItems.GetSpecialPrices();
        }

#region MasterData management. 
        //This is supposed to be in a database, so unit test also could use that instead getting them from here.


        public List<ShopingCart> GetItems()
        {
           
            return scannedItems;
        }

        public ItemMaster GetItemMasterData(string sku)
        {
            
            return masterItems.Where(x => x.SKU == sku).FirstOrDefault();
        }

        public SpecialPrice GetItemSpecialPrice(string sku)
        {

            return specialPrices.Where(x => x.SKU == sku).FirstOrDefault();
        }


        public ShopingCart GetItem(string sku)
        {

            return scannedItems.Where(x=>x.SKU==sku).FirstOrDefault();
        }
#endregion

        public void Scan(string sku)
        {
            if (masterItems.Count > 0)
            {
                ItemMaster scannedItemMaster = masterItems.Where(x => x.SKU == sku).FirstOrDefault();
                if (scannedItemMaster != null)
                {
                    ShopingCart scannedItem = scannedItems.Where(x => x.SKU == sku).FirstOrDefault();
                    //No price calculation in scan time. Calculated in GetTotalPrice

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
            //set shopping cart price here, because of the frequent changes
            foreach (ShopingCart scannedItem in scannedItems)
            {
                ItemMaster scannedItemMaster = masterItems.Where(x => x.SKU == scannedItem.SKU).FirstOrDefault();
                SpecialPrice specialPrice = specialPrices.Where(x => x.SKU==scannedItem.SKU).FirstOrDefault();
                if (specialPrice != null)
                {
                    //Special Price is available but only apply if the qty is greater or equal with the spec price qty
                    if (scannedItem.Quantity >= specialPrice.Quantity)
                        scannedItem.LineTotal = scannedItem.Quantity * specialPrice.DiscountedPrice;
                    else
                        scannedItem.LineTotal = scannedItem.Quantity * scannedItemMaster.UnitPrice;
                }
                else
                {
                    //No special price available, use standard price from Item Master
                    scannedItem.LineTotal = scannedItem.Quantity * scannedItemMaster.UnitPrice;
                }
            }

            decimal totalPrice = scannedItems.Sum(x => x.LineTotal);

            return totalPrice;
        }
    }
}
