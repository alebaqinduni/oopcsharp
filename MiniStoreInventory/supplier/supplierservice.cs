using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class SupplierService
    {
        private SupplierRepo _repo = new SupplierRepo();

        public void SaveSupplier(SupplierModel item)
        {
            _repo.SaveInFile(item);
            File.AppendAllText("history.txt", "Supplier added: " + item.GetName() + Environment.NewLine);
        }

        public List<SupplierModel> GetAllSuppliers()
        {
            return _repo.GetAllSuppliers();
        }

        
        public List<SupplierModel> SearchByPartialName(string name)
        {
            List<SupplierModel> products = _repo.GetAllSuppliers();
            List<SupplierModel> answer = new List<SupplierModel>();
            foreach (SupplierModel p in products)
            {
                if (p.GetName().ToLower().Contains(name.ToLower()))
                {
                    answer.Add(p);
                }
            }
            return answer;
        }
        public SupplierModel SearchByName(string name)
        {
            foreach (SupplierModel item in _repo.GetAllSuppliers())
            {
                if (item.GetName() == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool DeleteSupplier(string name)
        {
            List<SupplierModel> items = _repo.GetAllSuppliers();
            int count = 0;
            foreach (SupplierModel item in _repo.GetAllSuppliers())
            {
                if (item.GetName() == name)
                {
                    items.RemoveAt(count);
                    _repo.SaveAllDataInFile(items);
                    File.AppendAllText("history.txt", "Supplier deleted: " + name + Environment.NewLine);
                    return true;
                }
                count++;
            }
            return false;
        }

        public bool UpdateSupplier(string oldname,string name,string phone,string company)
        {
            List<SupplierModel> items = _repo.GetAllSuppliers();
            int count = 0;
            foreach (SupplierModel item in items)
            {
                if (item.GetName() == oldname)
                {
                    item.SetName(name);
                    item.SetPhone(phone);
                    item.SetCompany(company);
                    _repo.SaveAllDataInFile(items);
                    File.AppendAllText("history.txt", "Supplier updated: " + name + Environment.NewLine);
                    return true;
                }
                count++;
            }
            return false;
        }

        
    }
}//
