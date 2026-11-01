using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class SupplierRepo
    {
        private readonly string file = "supplier.txt";

        public void SaveInFile(SupplierModel item)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine(item.ToString());
            }
        }

        public void SaveAllDataInFile(List<SupplierModel> items)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                foreach (SupplierModel item in items)
                    sw.WriteLine(item.ToString());
            }
        }

        public List<SupplierModel> GetAllSuppliers()
        {
            List<SupplierModel> items = new List<SupplierModel>();
            if (!File.Exists(file))
                return items;

            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        SupplierModel item = new SupplierModel(parts[0], parts[1], parts[2]);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

    }
}
