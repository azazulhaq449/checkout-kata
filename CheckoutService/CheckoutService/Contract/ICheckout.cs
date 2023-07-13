
namespace KataCheckout.Contract
{
    public interface ICheckout
    {
        /// <summary>
        /// Scan roduct
        /// </summary>
        /// <param name="item"></param>
        void Scan(string item);
        /// <summary>
        /// Get Total Price of the scanned products
        /// </summary>
        /// <returns></returns>
        int GetTotalPrice();
        /// <summary>
        /// Set price rule with special price as well
        /// </summary>
        /// <param name="item"></param>
        /// <param name="unitPrice"></param>
        /// <param name="quantity"></param>
        /// <param name="specialPrice"></param>
        void SetPricingRule(string item, int unitPrice, int quantity, int specialPrice);
        /// <summary>
        /// Set price rule without special price
        /// </summary>
        /// <param name="item"></param>
        /// <param name="unitPrice"></param>
        void SetPricingRule(string item, int unitPrice);
    }
}
