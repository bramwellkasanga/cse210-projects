using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first order (USA customer)
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        
        Product product1 = new Product("Laptop", "P001", 999.99, 1);
        Product product2 = new Product("Mouse", "P002", 25.50, 2);
        Product product3 = new Product("USB Cable", "P003", 12.99, 3);
        
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create second order (International customer)
        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sarah Johnson", address2);
        Order order2 = new Order(customer2);
        
        Product product4 = new Product("Keyboard", "P004", 79.99, 1);
        Product product5 = new Product("Monitor", "P005", 299.99, 2);
        
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Order 1 details
        Console.WriteLine("ORDER 1");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        // Display Order 2 details
        Console.WriteLine("ORDER 2");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}