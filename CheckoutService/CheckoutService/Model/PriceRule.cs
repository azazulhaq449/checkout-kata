
namespace KataCheckout.Model
{
    /// <summary>
    /// Define Price Rule
    /// </summary>
    public class PriceRule
    {
        /// <summary>
        /// Create Price Rule
        /// </summary>
        /// <param name="unitPrice"></param>
        /// <param name="quantity"></param>
        /// <param name="speicalPrice"></param>
        public PriceRule(int unitPrice, int? quantity, int? speicalPrice) {
            Quantity = quantity;
            UnitPrice = unitPrice;
            SpecialPrice = speicalPrice;
        }
        /// <summary>
        /// Create Price Rule without special price
        /// </summary>
        /// <param name="unitPrice"></param>
        public PriceRule(int unitPrice)
        {
            UnitPrice = unitPrice;
        }
        public int? SpecialPrice { get; private set; }
        public int? Quantity { get; private set; }
        public int UnitPrice { get; private set; }

    }
}
