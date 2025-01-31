using System;

class Program
{
    static void Main(string[] args)
    {
        // Address:
        Address address1 = new Address("123 Main St", "New York", "NY 10001", "USA");
        Address address2 = new Address("789 Oak Blvd", "Toronto", "ON M5H 2N2", "Canada");
        Address address3 = new Address("456 Avenida Libertador", "Buenos Aires", "CABA", "Argentina");

        // customers
        Customer customer1 = new Customer("Julian Gonzalez", address1);
        Customer customer2 = new Customer("Maria Rodriguez", address2);
        Customer customer3 = new Customer("Jenifer Martinez", address3);

        // Poducts:
        Product product1 = new Product("Notebook", "A200", 0.5, 2);
        Product product2 = new Product("Whiteboard", "B130", 10, 1);
        Product product3 = new Product("Eraser", "c200", 0.1, 5);
        Product product4 = new Product("Marker", "D123", 0.7, 9);
        Product product5 = new Product("Sticky Notes", "A345", 1, 6);


        // Orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product5);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product2);

        Order order3 = new Order(customer3);
        order3.AddProduct(product4);
        order3.AddProduct(product1);

        // display infrormation
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total cost: {order1.GetTotalCost()}");
        Console.WriteLine(" ");

        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total cost: {order2.GetTotalCost()}");
        Console.WriteLine(" ");

        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total cost: {order3.GetTotalCost()}");
        Console.WriteLine(" ");
    }
}