using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class CategoryRepo
    {
        private readonly string file = "category.txt";

        public void SaveInFile(CategoryModel item)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine(item.ToString());
            }
        }

        public void SaveAllDataInFile(List<CategoryModel> items)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                foreach (CategoryModel item in items)
                    sw.WriteLine(item.ToString());
            }
        }

        public List<CategoryModel> GetAllCategorys()
        {
            List<CategoryModel> items = new List<CategoryModel>();
            if (!File.Exists(file))
                return items;

            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        CategoryModel item = new CategoryModel(parts[0], parts[1]);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

    }
}
