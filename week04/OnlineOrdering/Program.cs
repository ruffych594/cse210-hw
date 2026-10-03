using System;

// This program shows off encapsulation. Each class keeps its own data private
// and only shares it through methods. Here we build two orders and print the results.
class Program
{
    static void Main(string[] args)
    {
        // ----- Order 1: a customer in the USA -----
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Emily Carter", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-101", 15.99m, 2));
        order1.AddProduct(new Product("USB-C Cable", "UC-202", 8.50m, 3));
        order1.AddProduct(new Product("Laptop Stand", "LS-303", 29.99m, 1));

        // ----- Order 2: a customer outside the USA -----
        Address address2 = new Address("45 Samora Machel Avenue", "Harare", "Harare Province", "Zimbabwe");
        Customer customer2 = new Customer("Tendai Moyo", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-404", 49.99m, 1));
        order2.AddProduct(new Product("Notebook", "NB-505", 3.25m, 4));

        // Put both orders in an array so we can display them with one loop
        Order[] orders = { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}
