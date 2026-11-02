using System;
using System.Collections.Generic;

namespace ClassStore
{
    internal class CustomerUI
    {
        private CustomerService service = new CustomerService();

        public void Start()
        {
            while (true)
            {
                ConsoleUI.Header("Customer Management");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  1. Add Customer");
                Console.WriteLine("  2. Update Customer");
                Console.WriteLine("  3. Delete Customer");
                Console.WriteLine("  4. View All");
                Console.WriteLine("  5. Search");
                Console.WriteLine("  6. Search by Partial Name: ");
                Console.WriteLine("  7. Back to Main Menu");
                Console.ResetColor();
                Console.Write("\nSelect option: ");
                string choice = Console.ReadLine();

                if (choice == "1") Add();
                else if (choice == "2") Update();
                else if (choice == "3") Delete();
                else if (choice == "4") DisplayAll();
                else if (choice == "5") Search();
                else if (choice == "6") SearchByPartialName();
                else if (choice == "7") break;
                else { ConsoleUI.Error("Invalid choice."); ConsoleUI.Pause(); }
            }
        }

        private CustomerModel TakeInput()
        {
            Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
            return new CustomerModel(name, phone, email);
        }

        private void Add()
        {
            ConsoleUI.Header("Add Customer");
            service.SaveCustomer(TakeInput());
            ConsoleUI.Success("Customer saved successfully.");
            ConsoleUI.Pause();
        }

        public void SearchByPartialName()
        {
            ConsoleUI.Header("Search by the Partial Name");
            Console.Write("Enter partial customer name: ");
            string name = Console.ReadLine();
            List<CustomerModel> p = service.SearchByPartialName(name);
            if (p.Count == 0)
            {
                ConsoleUI.Error("No matching products found.");
            }
            else
            {
                DisplayCustomerTable(p);
            }
            ConsoleUI.Pause();
        }

        private void DisplayCustomerTable(List<CustomerModel> items)
        {
        if (items.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(
        "  {0,-15} | {1,-20} | {2,9}",
        "NAME", "PHONE", "EMAIL");
        Console.WriteLine("  " + new string('-', 61));
        foreach (CustomerModel item in items)
        {
        Console.WriteLine(
            "  {0,-15} | {1,-20} | {2,9}",
            item.GetName(),
            item.GetPhone(),
            item.GetEmail());
        }
        Console.ResetColor();
        }
        private void Update()
        {
            ConsoleUI.Header("Update Customer");
            Console.Write("Enter current name: ");
        string oldName = Console.ReadLine();
        if (service.SearchByName(oldName) == null)
        {
            ConsoleUI.Error("Customer not found.");
        }
        else
        {
            Console.WriteLine("Enter the new details:");
            CustomerModel item = TakeInput();
            if (service.UpdateCustomer(oldName, item.GetPhone(), item.GetEmail()))
                ConsoleUI.Success("Customer updated.");
        }
            ConsoleUI.Pause();
        }

        // private void UpdateProduct()
        // {
        //     ConsoleUI.Header("Update Product");
        //     // Update is handled in the Update method above.
        //     ConsoleUI.Pause();
        // }

        private void Delete()
        {
            ConsoleUI.Header("Delete Customer");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (service.DeleteCustomer(name))
                ConsoleUI.Success("Customer deleted.");
            else
                ConsoleUI.Error("Customer not found.");
            ConsoleUI.Pause();
        }

        private void DisplayAll()
        {
            ConsoleUI.Header("All Customers");
            List<CustomerModel> items = service.GetAllCustomers();
            if (items.Count == 0) Console.WriteLine("No records found.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  {0,-22} | {1,-18} | {2,-28}", "NAME", "PHONE", "EMAIL");
            Console.WriteLine("  " + new string('-', 76));
            foreach (CustomerModel item in items)
                Console.WriteLine("  {0,-22} | {1,-18} | {2,-28}", item.GetName(), item.GetPhone(), item.GetEmail());
            Console.ResetColor();
            ConsoleUI.Pause();
        }

        private void Search()
        {
            ConsoleUI.Header("Search Customer");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            CustomerModel item = service.SearchByName(name);
            if (item == null) ConsoleUI.Error("Customer not found.");
            else Console.WriteLine(item.Display());
            ConsoleUI.Pause();
        }
    }
}//
