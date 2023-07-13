using KataCheckout.Contract;
using KataCheckout.Exception;
using KataCheckout.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KataCheckoutService.Test
{
    [TestClass]
    public class CheckoutServiceTest
    {
        private ICheckout _checkout;

        [TestInitialize]
        public void Init() {
            _checkout = new CheckoutService();
            _checkout.SetPricingRule("ProductA", 20, 3, 50);
            _checkout.SetPricingRule("ProductB", 30, 2, 45);
            _checkout.SetPricingRule("ProductC", 40);
            _checkout.SetPricingRule("ProductD", 50);
        }

        [TestMethod]
        public void GetTotalPrice_NoSpecialPrices_ReturnsCorrectTotal()
        {
            //Mock Data
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductB");
            _checkout.Scan("ProductC");
            _checkout.Scan("ProductD");

            int totalPrice = _checkout.GetTotalPrice();

            Assert.AreEqual(140, totalPrice);
        }

        [TestMethod]
        public void GetTotalPrice_WithMultipleItems_ButNotSpecialQUantity_ReturnsCorrectTotal()
        {
            //Mock Data ProductA have 2 items but couldn't reach to 3
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductB");
            _checkout.Scan("ProductC");
            _checkout.Scan("ProductD");

            int totalPrice = _checkout.GetTotalPrice();

            Assert.AreEqual(160, totalPrice);
        }

        [TestMethod]
        public void GetTotalPrice_WithSpecialPrice_ReturnsCorrectTotal()
        {
            //Mock Data ProductA have 3 items avail special discount
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductB");
            _checkout.Scan("ProductC");
            _checkout.Scan("ProductD");

            int totalPrice = _checkout.GetTotalPrice();

            Assert.AreEqual(170, totalPrice);
        }

        [TestMethod]
        public void GetTotalPrice_WithMultipleSpecialPrice_ReturnsCorrectTotal()
        {
            //Mock Data ProductA and ProductB have items to avail special discount
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductA");
            _checkout.Scan("ProductB");
            _checkout.Scan("ProductB");
            _checkout.Scan("ProductC");
            _checkout.Scan("ProductD");

            int totalPrice = _checkout.GetTotalPrice();

            Assert.AreEqual(185, totalPrice);
        }

        [TestMethod]
        public void GetTotalPrice_InvalidItem_ThrowsServiceException()
        {
            Assert.ThrowsException<KataCheckoutException>(()=> _checkout.Scan("InvalidProduct"));
        }
        [TestCleanup]
        public void Cleanup()
        {
            _checkout = null;
        }
    }
}
