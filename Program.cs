using System;
using System.Collections.Generic;

namespace Ex4T3
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class Customer
    {
        public int Id;
        public string Name;
        public string Email;
        public List<Product> ShoppingList;

        public Customer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            ShoppingList = new List<Product>();
        }

        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine("Shopping List:");
            foreach (var product in ShoppingList)
            {
                Console.WriteLine($"  - {product.Name} (${product.Price})");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Customer Cust1 = new Customer(1, "Johm Doe", "john.doe@email.com");
            Customer Cust2 = new Customer(2, "Jane Smith", "jane.smith@email.com");

            Product p1 = new Product(101, "Keyboard", 49.99);
            Product p2 = new Product(102, "Mouse", 25.50);
            Product p3 = new Product(103, "Monitor", 150.00);


            Cust1.ShoppingList.Add(p1);
            Cust1.ShoppingList.Add(p2);
            Cust2.ShoppingList.Add(p3);


            Console.WriteLine("Customer 1 Information:");
            Cust1.DisplayCustomerInfo();
            Console.WriteLine();

            Console.WriteLine("Customer 2 Information:");
            Cust2.DisplayCustomerInfo();
        }
    }
}
