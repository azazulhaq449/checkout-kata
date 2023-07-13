# checkout-kata


## Problem Description

In a normal supermarket, we need to implement a checkout system that calculates the total price based on the scanned items and pricing rules. The items are identified using Stock Keeping Units (SKUs) represented by individual letters of the alphabet (A, B, C, and so on). Each item has a unit price, and some items have special pricing rules (e.g., buy N of them for a special price).

The current pricing and offers are as follows:

| SKU | Unit Price | Special Price |
| --- | --- | --- |
| A | 50 | 3 for 130 |
| B | 30 | 2 for 45 |
| C | 20 | |
| D | 15 | |

#Solution

The solution provides an implementation of the ICheckout interface using the Checkout class. The class internally stores the pricing rules and scanned items. Here's an overview of the key components:

ICheckout: The interface that defines the methods for setting pricing rules, scanning items, and getting the total price.
CheckoutService: The class that implements the ICheckout interface. It internally maintains a dictionary of pricing rules and scanned items. The SetPricingRule method allows dynamic setting of pricing rules. The Scan method adds scanned items to the internal dictionary, and the GetTotalPrice method calculates the total price based on the pricing rules and scanned items.

#Conclusion
The Checkout-kata system provides a flexible and extensible solution for calculating the total price based on pricing rules and scanned items.