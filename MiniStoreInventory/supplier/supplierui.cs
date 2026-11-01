using System;
using System.Collections.Generic;

namespace ClassStore
{
    internal class SupplierUI
    {
        private SupplierService service = new SupplierService();

        public void Start()
        {
            while (true)
            {
                ConsoleUI.Header("Supplier Management");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  1. Add Supplier");
                Console.WriteLine("  2. Update Supplier");
                Console.WriteLine("  3. Delete Supplier");
                Console.WriteLine("  4. View All");
                Console.WriteLine("  5. Search");
                Console.WriteLine("  6. Back to Main Menu");
                Console.ResetColor();
                Console.Write("\nSelect option: ");
                string choice = Console.ReadLine();

                if (choice == "1") Add();
                else if (choice == "2") Update();
                else if (choice == "3") Delete();
                else if (choice == "4") DisplayAll();
                else if (choice == "5") Search();
                else if (choice == "6") break;
                else { ConsoleUI.Error("Invalid choice."); ConsoleUI.Pause(); }
            }
        }

        private SupplierModel TakeInput()
        {
            Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Company: ");
        string company = Console.ReadLine();
            return new SupplierModel(name, phone, company);
        }

        private void Add()
        {
            ConsoleUI.Header("Add Supplier");
            service.SaveSupplier(TakeInput());
            ConsoleUI.Success("Supplier saved successfully.");
            ConsoleUI.Pause();
        }

        private void Update()
        {
            ConsoleUI.Header("Update Supplier");
            Console.Write("Enter current name: ");
        string oldName = Console.ReadLine();
        if (service.SearchByName(oldName) == null)
        {
            ConsoleUI.Error("Supplier not found.");
        }
        else
        {
            Console.WriteLine("Enter the new details:");
            SupplierModel item = TakeInput();
            if (service.UpdateSupplier(oldName,item.GetName(),item.GetPhone(),item.GetCompany()))
                ConsoleUI.Success("Supplier updated.");
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
            ConsoleUI.Header("Delete Supplier");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (service.DeleteSupplier(name))
                ConsoleUI.Success("Supplier deleted.");
            else
                ConsoleUI.Error("Supplier not found.");
            ConsoleUI.Pause();
        }

        private void DisplayAll()
        {
            ConsoleUI.Header("All Suppliers");
            List<SupplierModel> items = service.GetAllSuppliers();
            if (items.Count == 0) Console.WriteLine("No records found.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  {0,-25} | {1,-18} | {2,-30}", "NAME", "PHONE", "COMPANY");
            Console.WriteLine("  " + new string('-', 82));
            foreach (SupplierModel item in items)
                Console.WriteLine("  {0,-25} | {1,-18} | {2,-30}", item.GetName(), item.GetPhone(), item.GetCompany());
            Console.ResetColor();
            ConsoleUI.Pause();
        }

        private void Search()
        {
            ConsoleUI.Header("Search Supplier");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            SupplierModel item = service.SearchByName(name);
            if (item == null) ConsoleUI.Error("Supplier not found.");
            else Console.WriteLine(item.Display());
            ConsoleUI.Pause();
        }
    }
}
