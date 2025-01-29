using Checkout.DAO;
using System;

namespace Checkout.Test
{
    public class Tests
    {
        private Checkout.BLL.CheckoutManager checkoutManager = new Checkout.BLL.CheckoutManager();


        [SetUp]
        public void Setup()
        {
        }




        [Test]
        public void AddItemToCheckout()
        {
            //Add items multiple times and check if the quantity is incresed or not
            checkoutManager = new Checkout.BLL.CheckoutManager();
            string sku = "A";

            checkoutManager.Scan(sku);
            checkoutManager.Scan(sku);
            checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetItems().Count, Is.EqualTo(1));
        }

        [TestCase("A",5)]
        [TestCase("B", 2)]
        [TestCase("C", 1)]
        [TestCase("D", 9)]
        public void AddItemToCheckoutAndValidateQty(string sku,int qty)
        {
            checkoutManager = new Checkout.BLL.CheckoutManager();
            for (int i = 0; i < qty; i++) 
                checkoutManager.Scan(sku);
  
            Assert.That(checkoutManager.GetItem(sku).Quantity, Is.EqualTo(qty));
        }

        [Test]
        public void CheckInvalidItem()
        {
            string sku = "X";

            Assert.Throws<ArgumentException>(() => checkoutManager.Scan(sku));
        }

        [Test]
        public void CheckoutPriceCalculation()
        {
            checkoutManager = new Checkout.BLL.CheckoutManager();
            string sku = "A";
            int unitPrice = 50;
            checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetTotalPrice(),Is.EqualTo(unitPrice));
        }

        //[TestCase("A", 5)]
        //[TestCase("B", 2)]
        [TestCase("C", 1)]
        [TestCase("D", 9)]
        public void CheckoutPriceCalculationWithMultipleQty(string sku, int qty)
        {
            checkoutManager = new Checkout.BLL.CheckoutManager();
            decimal lineTotal = 0;
            ItemMaster itemMaster= checkoutManager.GetItemMasterData(sku);
            lineTotal = itemMaster.UnitPrice * qty;
            for (int i = 0; i < qty; i++)
                checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetTotalPrice(), Is.EqualTo(lineTotal));
        }

        [Test]
        public void CheckoutPriceCalculationWithMultipleItemsAndQty()
        {
            checkoutManager = new Checkout.BLL.CheckoutManager();
            string sku="D";
            int qty=5;
            decimal lineTotal = 0;
            ItemMaster itemMaster = checkoutManager.GetItemMasterData(sku);
            lineTotal = itemMaster.UnitPrice * qty;
            for (int i = 0; i < qty; i++)
                checkoutManager.Scan(sku);
            
            
            sku = "C";
            qty = 3;
            itemMaster = checkoutManager.GetItemMasterData(sku);
            lineTotal = lineTotal+itemMaster.UnitPrice * qty;
            for (int i = 0; i < qty; i++)
                checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetTotalPrice(), Is.EqualTo(lineTotal));
        }


        [Test]
        public void CheckoutSpecialPriceCalculation()
        {
            checkoutManager = new Checkout.BLL.CheckoutManager();
            string sku = "A";
            int unitPrice = 130;
            checkoutManager.Scan(sku);
            checkoutManager.Scan(sku);
            checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetTotalPrice(), Is.EqualTo(unitPrice));
        }

        [Test]
        public void CheckoutSpecialPriceCalculationWithMultipleItemsAndQty()
        {
            //mixing item with special price and normal price
            checkoutManager = new Checkout.BLL.CheckoutManager();
            string sku = "A";
            int qty = 5;
            decimal totalPrice = 0;
            ItemMaster itemMaster = checkoutManager.GetItemMasterData(sku);
            SpecialPrice specialPrice = checkoutManager.GetItemSpecialPrice(sku);
            if (specialPrice != null)
            {
                if (qty >= specialPrice.Quantity)
                {
                    totalPrice = specialPrice.DiscountedPrice * qty;
                }
            }
            else 
                totalPrice = itemMaster.UnitPrice * qty;
                        
            for (int i = 0; i < qty; i++)
                checkoutManager.Scan(sku);


            sku = "C";
            qty = 3;
            itemMaster = checkoutManager.GetItemMasterData(sku);
            specialPrice = checkoutManager.GetItemSpecialPrice(sku);
            if (specialPrice != null)
            {
                if (qty >= specialPrice.Quantity)
                {
                    totalPrice = totalPrice+specialPrice.DiscountedPrice * qty;
                }
            }
            else
                totalPrice = totalPrice+itemMaster.UnitPrice * qty;
            for (int i = 0; i < qty; i++)
                checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetTotalPrice(), Is.EqualTo(totalPrice));
        }


        [TestCase("A", 5)]
        [TestCase("B", 2)]
        [TestCase("C", 1)]
        [TestCase("D", 9)]
        [TestCase("A", 105)]
        [TestCase("B", 3)]
        [TestCase("C", 99)]
        [TestCase("D", 50)]
        public void CheckoutSpecialPriceCalculationWithMultipleQty(string sku, int qty)
        {
            checkoutManager = new Checkout.BLL.CheckoutManager();
            decimal totalPrice = 0;
            ItemMaster itemMaster = checkoutManager.GetItemMasterData(sku);

            SpecialPrice specialPrice = checkoutManager.GetItemSpecialPrice(sku);
            if (specialPrice != null)
            {
                if (qty >= specialPrice.Quantity)
                {
                    totalPrice = specialPrice.DiscountedPrice * qty;
                }
            }
            else
                totalPrice = itemMaster.UnitPrice * qty;
 
            for (int i = 0; i < qty; i++)
                checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetTotalPrice(), Is.EqualTo(totalPrice));
        }

    }
}