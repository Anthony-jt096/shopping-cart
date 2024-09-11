using System;
using System.Collections.Generic;

class Program
{
    // Define a class to represent an item in the cart
    class CartItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public CartItem(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double TotalPrice()
        {
            return Price * Quantity;
        }
    }

    static void Main()
    {
        List<CartItem> cart = new List<CartItem>();
        bool running = true;

        while (running)
        {
            // Display the menu
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add an item to the cart");
            Console.WriteLine("2. View the cart");
            Console.WriteLine("3. Calculate the total price");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddItemToCart(cart);
                    break;
                case "2":
                    ViewCart(cart);
                    break;
                case "3":
                    CalculateTotalPrice(cart);
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    static void AddItemToCart(List<CartItem> cart)
    {
        Console.Write("Enter the name of the item: ");
        string name = Console.ReadLine();

        double price;
        while (true)
        {
            Console.Write("Enter the price of the item: ");
            if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                break;
            Console.WriteLine("Invalid input. Please enter a valid price.");
        }

        int quantity;
        while (true)
        {
            Console.Write("Enter the quantity of the item: ");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                break;
            Console.WriteLine("Invalid input. Please enter a valid quantity.");
        }

        cart.Add(new CartItem(name, price, quantity));
        Console.WriteLine("Item added to the cart.");
    }

    static void ViewCart(List<CartItem> cart)
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("The cart is empty.");
            return;
        }

        Console.WriteLine("Current Cart:");
        foreach (var item in cart)
        {
            Console.WriteLine($"{item.Name}: ${item.Price:F2} x {item.Quantity} = ${item.TotalPrice():F2}");
        }
    }

    static void CalculateTotalPrice(List<CartItem> cart)
    {
        double total = 0;
        foreach (var item in cart)
        {
            total += item.TotalPrice();
        }
        Console.WriteLine($"Total price of items in the cart: ${total:F2}");
    }
}

