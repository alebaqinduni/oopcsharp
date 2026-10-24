using System;
using System.Collections.Generic;
using System.IO;
public class ProductRepository
{
    private readonly string _filePath = "products.txt";


    public void Save(Product product)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine(product.ToString());
        }
    }


    public void SaveAll(List<Product> products)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, false))
        {
            foreach (Product product in products)
                writer.WriteLine(product.ToString());
        }
    }


    public List<Product> GetAll()
    {
    List<Product> products = new List<Product>();
    if (!File.Exists(_filePath))
    {
        return products;
    }
    foreach (string line in File.ReadAllLines(_filePath))
    {
        string[] parts = line.Split(',');
        if (parts.Length != 4)
        {
            continue;
        }
        int id = int.Parse(parts[0]);
        int price = int.Parse(parts[2]);
        int quantity = int.Parse(parts[3]);

        Product p = new Product(id, parts[1], price, quantity);
        products.Add(p);
    }
    return products;
}

}
