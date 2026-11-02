using System;
using System.Collections.Generic;

namespace ClassStore
{
    internal class ProductUI
    {
        private ProductService service = new ProductService();

        public void Start()
        {
            while (true)
            {
                ConsoleUI.Header("Product Management");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  1. Add Product");
                Console.WriteLine("  2. Update Product");
                Console.WriteLine("  3. Delete Product");
                Console.WriteLine("  4. View All");
                Console.WriteLine("  5. Search");
                Console.WriteLine("  6. Search by Partial Name: ");
                Console.WriteLine("  7. Sort Ascending ");//a-z
                Console.WriteLine("  8. Sort Descending ");//z-a
                Console.WriteLine("  9. Back to Main Menu");
                Console.ResetColor();
                Console.Write("\nSelect option: ");
                string choice = Console.ReadLine();

                if (choice == "1") Add();
                else if (choice == "2") UpdateProduct();
                else if (choice == "3") Delete();
                else if (choice == "4") DisplayAll();
                else if (choice == "5") Search();
                else if (choice == "6") SearchByPartialName();
                else if (choice == "7") DisplayAscending();
                else if (choice == "8") DisplayDescending();
                else if (choice == "9") break;
                else
                {
                    ConsoleUI.Error("Invalid choice.");
                    ConsoleUI.Pause();
                }
            }
            }

        private ProductModel TakeInput()
        {
            Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Purchase Price: ");
        float purchasePrice = float.Parse(Console.ReadLine());
        Console.Write("Sale Price: ");
        float salePrice = float.Parse(Console.ReadLine());
        Console.Write("Discount: ");
        float discount = float.Parse(Console.ReadLine());
            return new ProductModel(name, description, purchasePrice, salePrice, discount);
        }

        private void Add()
        {
            ConsoleUI.Header("Add Product");
            service.SaveProduct(TakeInput());
            ConsoleUI.Success("Product saved successfully.");
            ConsoleUI.Pause();
        }

        private void UpdateProduct()
        {
            ConsoleUI.Header("Update Product");
            Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Product Sale Price: ");
        float price = float.Parse(Console.ReadLine());
        if (service.UpdateProductPrice(name, price)) //price only
            ConsoleUI.Success("Product updated.");
        else
            ConsoleUI.Error("Product not found.");
            ConsoleUI.Pause();
        }

        private void Delete()
        {
            ConsoleUI.Header("Delete Product");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (service.DeleteProduct(name))
                ConsoleUI.Success("Product deleted.");
            else
                ConsoleUI.Error("Product not found.");
            ConsoleUI.Pause();
        }

        // private void DisplayAll()
        // {
        //     ConsoleUI.Header("All Products");
        //     List<ProductModel> items = service.GetAllProducts();
        //     if (items.Count == 0)
        //     Console.WriteLine("No records found.");
        //     Console.WriteLine("NAME\tDESCRIPTION\tPURCHASE\tSALE\tDISCOUNT");
        //     foreach (ProductModel item in items)
        //     {
        //     Console.WriteLine(
        //     item.GetName() + "\t" +
        //     item.GetDescription() + "\t" +
        //     item.GetPurchasePrice() + "\t" +
        //     item.GetSalePrice() + "\t" +
        //     item.GetDiscount()
        //                     );
        //     }
        //     ConsoleUI.Pause();
        // }


        private void DisplayAll()
        {
        ConsoleUI.Header("All Products");
        List<ProductModel> items = service.GetAllProducts();
        if (items.Count == 0)
        Console.WriteLine("No records found.");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  {0,-18} | {1,-20} | {2,12} | {3,12} | {4,10}",
        "NAME", "DESCRIPTION", "PURCHASE", "SALE", "DISCOUNT");
        Console.WriteLine("  " + new string('-', 91));
        foreach (ProductModel item in items)
        {
            Console.WriteLine("  {0,-18} | {1,-20} | {2,12} | {3,12} | {4,10}",
            item.GetName(),
            item.GetDescription(),
            item.GetPurchasePrice(),
            item.GetSalePrice(),
            item.GetDiscount());
        }
        Console.ResetColor();
        ConsoleUI.Pause();
        }

        private void Search()
        {
            ConsoleUI.Header("Search Product");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            ProductModel item = service.SearchByName(name);
            if (item == null) ConsoleUI.Error("Product not found.");
            else Console.WriteLine(item.Display());
            ConsoleUI.Pause();
        }
        private void DisplayAscending()
        {
            ConsoleUI.Header("Products - Ascending Order");
            List<ProductModel> items = service.SortAscending();
            DisplayProductTable(items);
            ConsoleUI.Pause();
        }

        private void DisplayDescending()
        {
            ConsoleUI.Header("Products - Descending Order");
            List<ProductModel> items = service.SortDescending();
            DisplayProductTable(items);
            ConsoleUI.Pause();
        }

        public void SearchByPartialName()
        {
            ConsoleUI.Header("Search by the Partial Name");
            Console.Write("Enter partial product name: ");
            string name = Console.ReadLine();
            List<ProductModel> p = service.SearchByPartialName(name);
            if (p.Count == 0)
            {
                ConsoleUI.Error("No matching products found.");
            }
            else
            {
                DisplayProductTable(p);
            }
            ConsoleUI.Pause();
        }


        private void DisplayProductTable(List<ProductModel> items)
        {
        if (items.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(
        "  {0,-15} | {1,-20} | {2,9} | {3,9} | {4,9}",
        "NAME", "DESCRIPTION", "PURCHASE", "SALE", "DISCOUNT");
        Console.WriteLine("  " + new string('-', 91));
        foreach (ProductModel item in items)
        {
        Console.WriteLine(
            "  {0,-15} | {1,-20} | {2,9} | {3,9} | {4,9}",
            item.GetName(),
            item.GetDescription(),
            item.GetPurchasePrice(),
            item.GetSalePrice(),
            item.GetDiscount());
        }
        Console.ResetColor();
        }


    }
}




