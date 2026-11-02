using System;
using System.Collections.Generic;

namespace ClassStore
{
    internal class CategoryUI
    {
        private CategoryService service = new CategoryService();

        public void Start()
        {
            while (true)
            {
                ConsoleUI.Header("Category Management");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  1. Add Category");
                Console.WriteLine("  2. Update Category");
                Console.WriteLine("  3. Delete Category");
                Console.WriteLine("  4. View Category: ");
                Console.WriteLine("  5. Search by category: ");
                Console.WriteLine("  6. Exact Match for Category: ");
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


        private CategoryModel TakeInput()
        {
            Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
            return new CategoryModel(name, description);
        }

        public void SearchByPartialName()
        {
            ConsoleUI.Header("Search by the Partial Name");
            Console.Write("Enter partial category name: ");
            string name = Console.ReadLine();
            List<CategoryModel> p = service.SearchByPartialName(name);
            if (p.Count == 0)
            {
                ConsoleUI.Error("No matching products found.");
            }
            else
            {
                DisplayCategoryTable(p);
            }
            ConsoleUI.Pause();
        }

        private void DisplayCategoryTable(List<CategoryModel> items)
        {
        if (items.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(
        "  {0,-15} | {1,-20} ",
        "NAME", "DESCRIPTION");
        Console.WriteLine("  " + new string('-', 91));
        foreach (CategoryModel item in items)
        {
        Console.WriteLine(
            "  {0,-15} | {1,-20} ",
            item.GetName(),
            item.GetDescription());
        }
        Console.ResetColor();
        }
        private void Add()
        {
            ConsoleUI.Header("Add Category");
            service.SaveCategory(TakeInput());
            ConsoleUI.Success("Category saved successfully.");
            ConsoleUI.Pause();
        }

        private void Update()
        {
            ConsoleUI.Header("Update Category");
            Console.Write("Enter current name: ");
        string oldName = Console.ReadLine();
        if (service.SearchByName(oldName) == null)
        {
            ConsoleUI.Error("Category not found.");
        }
        else
        {
            Console.WriteLine("Enter the new details:");
            CategoryModel item = TakeInput();
            if (service.UpdateCategory(oldName,item.GetName(), item.GetDescription())) // Update name and description
                ConsoleUI.Success("Category updated.");
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
            ConsoleUI.Header("Delete Category");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (service.DeleteCategory(name))
                ConsoleUI.Success("Category deleted.");
            else
                ConsoleUI.Error("Category not found.");
            ConsoleUI.Pause();
        }
// //-------------------------------------------------------------------------
//         private void CategoryMatch()
//         {    //
//             ConsoleUI.Header("All Categorys");
//             List<CategoryModel> items = service.GetAllCategorys();
//             if (items.Count == 0) Console.WriteLine("No records found.");
//             Console.ForegroundColor = ConsoleColor.Cyan;
//             Console.WriteLine("  {0,-25} | {1,-45}", "CATEGORY", "DESCRIPTION");
//             Console.WriteLine("  " + new string('-', 76));
//             foreach (CategoryModel item in items)
//                 Console.WriteLine("  {0,-25} | {1,-45}", item.GetName(), item.GetDescription());
//             Console.ResetColor();
//             ConsoleUI.Pause();
//         }

        //----------------------------------------------------------
        private void DisplayAll()
        {
            ConsoleUI.Header("All Categorys");
            List<CategoryModel> items = service.GetAllCategorys();
            if (items.Count == 0) Console.WriteLine("No records found.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  {0,-25} | {1,-45}", "CATEGORY", "DESCRIPTION");
            Console.WriteLine("  " + new string('-', 76));
            foreach (CategoryModel item in items)
                Console.WriteLine("  {0,-25} | {1,-45}", item.GetName(), item.GetDescription());
            Console.ResetColor();
            ConsoleUI.Pause();
        }

        private void Search()
        {
            ConsoleUI.Header("Search Category: ");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            CategoryModel item = service.SearchByName(name);
            if (item == null) ConsoleUI.Error("Category not found.");
            else Console.WriteLine(item.Display());
            ConsoleUI.Pause();
        }
    }
}//
