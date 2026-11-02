using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class CustomerRepo
    {
        private readonly string file = "customer.txt";

        public void SaveInFile(CustomerModel item)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine(item.ToString());
            }
        }

        public void SaveAllDataInFile(List<CustomerModel> items)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                foreach (CustomerModel item in items)
                    sw.WriteLine(item.ToString());
            }
        }

        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> items = new List<CustomerModel>();
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
                        CustomerModel item = new CustomerModel(parts[0], parts[1], parts[2]);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

    }
}//
