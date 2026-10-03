using System;
using System.Collections.Generic;

// The Order class ties everything together.
// It has a list of Products and one Customer, and works out costs and labels.
public class Order
{
    // Shipping prices are kept in one place so they're easy to change later
    private const decimal UsaShippingCost = 5m;
    private const decimal InternationalShippingCost = 35m;

    private List<Product> _products = new List<Product>();
    private Customer _customer;

    // Constructor: an order starts with a customer, and products are added after
    public Order(Customer customer)
    {
        _customer = customer;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    // Adds a product to this order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Works out the shipping cost: $5 inside the USA, $35 anywhere else
    public decimal GetShippingCost()
    {
        if (_customer.LivesInUsa())
        {
            return UsaShippingCost;
        }
        else
        {
            return InternationalShippingCost;
        }
    }

    // Total price = the cost of every product added together + one-time shipping
    public decimal GetTotalCost()
    {
        decimal total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += GetShippingCost();

        return total;
    }

    // Builds the packing label: the name and product id of each product
    public string GetPackingLabel()
    {
        string label = "PACKING LABEL\n";

        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label;
    }

    // Builds the shipping label: the customer's name and full address
    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}\n";
    }
}
