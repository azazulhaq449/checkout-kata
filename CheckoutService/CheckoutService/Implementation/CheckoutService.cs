using KataCheckout.Contract;
using KataCheckout.Exception;
using KataCheckout.Model;
using System.Collections.Generic;

namespace KataCheckout.Implementation
{
    public class CheckoutService : ICheckout
    {
        private Dictionary<string, int> _scannedItems;
        private Dictionary<string, PriceRule> _priceRules;

        public CheckoutService()
        {
            _scannedItems = new Dictionary<string, int>();
            _priceRules = new Dictionary<string, PriceRule>();
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var product in _scannedItems)
            {
                string productSku = product.Key;
                int quantity = product.Value;
                totalPrice += GetProductPrice(productSku, quantity);
            }

            return totalPrice;
        }

        

        public void Scan(string item)
        {
            if (_priceRules.ContainsKey(item))
            {
                if (_scannedItems.ContainsKey(item))
                    _scannedItems[item]++;
                else
                    _scannedItems[item] = 1;
            }
            else
            {
                throw new KataCheckoutException($"Invalid item :{item}", item);
            }
        }

        public void SetPricingRule(string item, int unitPrice, int quantity, int specialPrice)
        {
            _priceRules[item] = new PriceRule(unitPrice, quantity, specialPrice);
        }

        public void SetPricingRule(string item, int unitPrice)
        {
            _priceRules[item] = new PriceRule(unitPrice);
        }

        private int GetProductPrice(string product, int quantity)
        {
            int totalPrice = 0;
            var specialPriceRule = _priceRules[product];
            if (specialPriceRule.SpecialPrice != null)
            {
                var specialPriceCount = quantity / specialPriceRule.Quantity.Value;
                int regularPriceCount = quantity % specialPriceRule.Quantity.Value;

                totalPrice += specialPriceCount * specialPriceRule.SpecialPrice.Value;
                totalPrice += regularPriceCount * specialPriceRule.UnitPrice;
            }
            else
            {
                //regular price 
                totalPrice += specialPriceRule.UnitPrice * quantity;
            }

            return totalPrice;
        }
    }
}
