using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class CategoryService
    {
        private CategoryRepo _repo = new CategoryRepo();

        public void SaveCategory(CategoryModel item)
        {
            _repo.SaveInFile(item);
            File.AppendAllText("history.txt", "Category added: " + item.GetName() + Environment.NewLine);
        }

        public List<CategoryModel> GetAllCategorys()
        {
            return _repo.GetAllCategorys();
        }

        public CategoryModel SearchByName(string name)
        {
            foreach (CategoryModel item in _repo.GetAllCategorys())
            {
                if (item.GetName() == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool DeleteCategory(string name)
        {
            List<CategoryModel> items = _repo.GetAllCategorys();
            int count = 0;
            foreach (CategoryModel item in _repo.GetAllCategorys())
            {
                if (item.GetName() == name)
                {
                    items.RemoveAt(count);
                    _repo.SaveAllDataInFile(items);
                    File.AppendAllText("history.txt", "Category deleted: " + name + Environment.NewLine);
                    return true;
                }
                count++;
            }
            return false;
        }

        public bool UpdateCategory(string oldName,string name,string description)
        {
            List<CategoryModel> items = _repo.GetAllCategorys();
            int count = 0;
            foreach (CategoryModel item in items)
            {
                if (item.GetName() == oldName)
                {
                    item.SetName(name);
                    item.SetDescription(description);
                    _repo.SaveAllDataInFile(items);
                    File.AppendAllText("history.txt", "Category updated: " + name + Environment.NewLine);
                    return true;
                }
                count++;
            }
            return false;
        }
    }
}
