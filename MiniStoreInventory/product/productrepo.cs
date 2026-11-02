using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class ProductRepo
    {
        private readonly string file = "product.txt";

        public void SaveInFile(ProductModel item)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine(item.ToString());
            }
        }

        public void SaveAllDataInFile(List<ProductModel> items)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                foreach (ProductModel item in items)
                    sw.WriteLine(item.ToString());
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> p = new List<ProductModel>();
            if (!File.Exists(file))
                return p;
            
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    {
                        ProductModel item = new ProductModel(parts[0], parts[1], float.Parse(parts[2]), float.Parse(parts[3]), float.Parse(parts[4]));
                        p.Add(item);
                    }
                }
            }
            return p;
        }
//
    }
}
