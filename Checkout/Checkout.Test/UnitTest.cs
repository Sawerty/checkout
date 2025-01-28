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

        [Test]
        public void AddItemToCheckoutAndValidateQty()
        {
            checkoutManager = new Checkout.BLL.CheckoutManager();
            string sku = "A";
            int qty = 1;

            checkoutManager.Scan(sku);
  
            Assert.That(checkoutManager.GetItem(sku).Quantity, Is.EqualTo(qty));
        }

        [Test]
        public void CheckInvalidItem()
        {
            string sku = "X";

            Assert.Throws<ArgumentException>(() => checkoutManager.Scan(sku));
        }

    }
}