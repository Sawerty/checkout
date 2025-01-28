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
            string sku = "A";
            int unitPrice = 50;
            checkoutManager.Scan(sku);

            Assert.That(checkoutManager.GetTotalPrice(),Is.EqualTo(unitPrice));
        }

        [TestCase("A", 5)]
        [TestCase("B", 2)]
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

    }
}