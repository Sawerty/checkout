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
            string sku = "A";

            checkoutManager.Scan(sku);



            Assert.That(checkoutManager.GetItems().Count, Is.GreaterThan(0));
        }

    }
}