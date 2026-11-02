using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class CustomerService
    {
        private CustomerRepo _repo = new CustomerRepo();

        public void SaveCustomer(CustomerModel item)
        {
            _repo.SaveInFile(item);
            File.AppendAllText("history.txt", "Customer added: " + item.GetName() + Environment.NewLine);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public CustomerModel SearchByName(string name)
        {
            foreach (CustomerModel item in _repo.GetAllCustomers())
            {
                if (item.GetName() == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool DeleteCustomer(string name)
        {
            List<CustomerModel> items = _repo.GetAllCustomers();
            int count = 0;
            foreach (CustomerModel item in _repo.GetAllCustomers())
            {
                if (item.GetName() == name)
                {
                    items.RemoveAt(count);
                    _repo.SaveAllDataInFile(items);
                    File.AppendAllText("history.txt", "Customer deleted: " + name + Environment.NewLine);
                    return true;
                }
                count++;
            }
            return false;
        }

        public bool UpdateCustomer(string name, string phone, string email)
        {
            List<CustomerModel> items = _repo.GetAllCustomers();
            int count = 0;
            foreach (CustomerModel item in items)
            {
                if (item.GetName() == name)
                {
                    item.SetPhone(phone);
                    item.SetEmail(email);
                    _repo.SaveAllDataInFile(items);
                    File.AppendAllText("history.txt", "Customer updated: " + name + Environment.NewLine);
                    return true;
                }
                count++;
            }
            return false;
        }
    }
}//
