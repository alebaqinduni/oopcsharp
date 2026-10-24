using System;
using System.Collections.Generic;

public class ProductUI
{
    private readonly ProductService _service;
    public ProductUI()
    {
        _service = new ProductService();
    }

    private int ReadNumber(string message)
    {
        int number;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out number)) return number;
            Console.WriteLine("Please enter a valid number.");
        }
    }

    private void Pause()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MINI STORE INVENTORY ===");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Search Product");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();
            if (choice == "1") AddProductUI();
            else if (choice == "2") ViewProductsUI();
            else if (choice == "3") SearchProductUI();
            else if (choice == "4") UpdateProductUI();
            else if (choice == "5") DeleteProductUI();
            else if (choice == "6") return;
            else { Console.WriteLine("Invalid choice!"); Pause(); }
        }
    }

    private void AddProductUI()
    {
        int id = ReadNumber("ID: ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        int price = ReadNumber("Price: ");
        int quantity = ReadNumber("Quantity: ");
        Product p = new Product(id, name, price, quantity);
        Console.WriteLine(_service.AddProduct(p) ? "Product added!" : "Invalid details or duplicate ID.");
        Pause();
    }

    private void ViewProductsUI()
    {
        List<Product> products = _service.GetAllProducts();
        if (products.Count == 0) Console.WriteLine("No products found.");
        foreach (Product p in products)
            Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Price: {p.Price} | Quantity: {p.Quantity}");
        Pause();
    }

    private void SearchProductUI()
    {
        int id = ReadNumber("Enter ID: ");
        Product p = _service.FindProduct(id);
        if (p == null) Console.WriteLine("Not found!");
        else Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Price: {p.Price} | Quantity: {p.Quantity}");
        Pause();
    }

    private void UpdateProductUI()
    {
        int id = ReadNumber("ID to update: ");
        Console.Write("New name: ");
        string name = Console.ReadLine();
        int price = ReadNumber("New price: ");
        int quantity = ReadNumber("New quantity: ");
        Console.WriteLine(_service.UpdateProduct(id, name, price, quantity) ? "Updated!" : "Not found or invalid details.");
        Pause();
    }

    private void DeleteProductUI()
    {
        int id = ReadNumber("ID to delete: ");
        Console.WriteLine(_service.DeleteProduct(id) ? "Deleted!" : "Not found!");
        Pause();
    }
}
