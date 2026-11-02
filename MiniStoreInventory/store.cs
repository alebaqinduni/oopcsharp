using System;

namespace ClassStore
{
    internal class Store
    {
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                string choice = MainMenu();
                if (choice == "1")
                {
                    ProductUI productUI = new ProductUI();
                    productUI.Start();
                }
                else if (choice == "2")
                {
                    CustomerUI customerUI = new CustomerUI();
                    customerUI.Start();
                }
                else if (choice == "3")
                {
                    CategoryUI categoryUI = new CategoryUI();
                    categoryUI.Start();
                }
                else if (choice == "4")
                {
                    SupplierUI supplierUI = new SupplierUI();
                    supplierUI.Start();
                }
                else if (choice == "5")
                {
                    History history = new History();
                    history.DisplayHistory();
                }
                else if (choice == "6")
                {
                    break;
                }
                else
                {
                    ConsoleUI.Error("Invalid choice. Please try again.");
                    ConsoleUI.Pause();
                }
            }
        }

        public string MainMenu()
        {
            ConsoleUI.Header("MINI INVENTORY STORE");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  1. Product Management");
            Console.WriteLine("  2. Customer Management");
            Console.WriteLine("  3. Category Management");
            Console.WriteLine("  4. Supplier Management");
            Console.WriteLine("  5. View History");
            Console.WriteLine("  6. Exit");
            Console.ResetColor();
            Console.Write("\n  Please select an option: ");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}//
