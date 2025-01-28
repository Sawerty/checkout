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
          

            checkoutManager.Scan("");



            Assert.That(checkoutManager.GetItems().Count, Is.GreaterThan(0));
        }

    }
}