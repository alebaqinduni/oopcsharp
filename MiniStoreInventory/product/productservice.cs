using System;
using System.Collections.Generic;
using System.IO;

namespace ClassStore
{
    internal class ProductService
    {
        private ProductRepo _repo = new ProductRepo();
        public void SaveProduct(ProductModel product)
        {
            _repo.SaveInFile(product);
            File.AppendAllText("history.txt", "Product added: " + product.GetName() + Environment.NewLine);
        }

        public List<ProductModel> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public ProductModel SearchByName(string name)
        {
            foreach (ProductModel product in _repo.GetAllProducts())
            {
                if (product.GetName() == name)
                {
                    return product;
                }
            }
            return null;
        }

        public bool DeleteProduct(string name)
        {
            List<ProductModel> product = _repo.GetAllProducts();
            int count = 0;
            foreach (ProductModel p in _repo.GetAllProducts())
            {
                if (p.GetName() == name)
                {
                    product.RemoveAt(count);
                    _repo.SaveAllDataInFile(product);
                    File.AppendAllText("history.txt", "Product deleted: " + name + Environment.NewLine);
                    return true;
                }
                count++;
            }
            return false;
        }

        public bool UpdateProductPrice(string name, float SalePrice)
        {
            List<ProductModel> products = _repo.GetAllProducts();
            foreach (ProductModel p in _repo.GetAllProducts())
            {
                if (p.GetName() == name)
                {
                    p.SetSalePrice(SalePrice);
                    _repo.SaveAllDataInFile(products);
                    File.AppendAllText("history.txt", "Product Price updated: " + name + Environment.NewLine);
                    return true;
                }
                
            }
            return false;
        }

        // p.SetName("Laptop");             // SETTER
        // Console.WriteLine(p.GetName()); // GETTER

        public List<ProductModel> SearchByPartialName(string name)
        {
            List<ProductModel> products = _repo.GetAllProducts();
            List<ProductModel> result = new List<ProductModel>();
            foreach (ProductModel p in products)
            {
                if (p.GetName().ToLower().Contains(name.ToLower()))
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public List<ProductModel> SortAscending()
        {
            List<ProductModel> products = _repo.GetAllProducts();
            for (int i = 0; i < products.Count-1; i++)
            {
                for (int j = i+1; j < products.Count; j++)
                {
                    string a = products[i].GetName();
                    string b = products[j].GetName();
                    if ( a[0] > b[0])
                    {
                        ProductModel temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }

                    // if (string.Compare(products[j].GetName(), products[j + 1].GetName(), true) > 0)
                    // {
                    //     ProductModel temp = products[j];
                    //     products[j] = products[j + 1];
                    //     products[j + 1] = temp;
                    // }
                }
            }

            return products;
        }

        public List<ProductModel> SortDescending()
        {
            List<ProductModel> products = _repo.GetAllProducts();

            for (int i = 0; i < products.Count-1; i++)
            {
                for (int j = i+1; j < products.Count; j++)
                {
                    string a = products[i].GetName();
                    string b = products[j].GetName();
                    if ( a[0] < b[0])
                    {
                        ProductModel temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }

            return products;
        }
    }
}

