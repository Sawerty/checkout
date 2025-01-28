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

            Assert.That(checkoutManager.GetItems().Count, Is.EqualTo(0));
        }

        [Test]
        public void CheckInvalidItem()
        {
            string sku = "X";

            

            Assert.Throws<ArgumentException>(() => checkoutManager.Scan(sku));
        }

    }
}