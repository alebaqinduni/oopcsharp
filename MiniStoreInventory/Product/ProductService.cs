using System.Collections.Generic;

public class ProductService
{
    private readonly ProductRepository _repository;
    public ProductService()
    {
        _repository = new ProductRepository();
    }
    public List<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }

    public Product FindProduct(int id)
    {
        foreach (Product p in _repository.GetAll())
            if (p.Id == id) return p;
        return null;
    }

    public bool AddProduct(Product product)
    {
        if (product.Id <= 0 || product.Price < 0 || product.Quantity < 0 ||
            string.IsNullOrWhiteSpace(product.Name) || product.Name.Contains(',')) return false;
        if (FindProduct(product.Id) != null) return false;
        _repository.Save(product);
        return true;
    }

    public bool UpdateProduct(int id, string name, int price, int quantity)
    {
        if (price < 0 || quantity < 0 || string.IsNullOrWhiteSpace(name) || name.Contains(',')) return false;
        List<Product> products = _repository.GetAll();
        foreach (Product p in products)
        {
            if (p.Id == id)
            {
                p.Name = name;
                p.Price = price;
                p.Quantity = quantity;
                _repository.SaveAll(products);
                return true;
            }
        }
        return false;
    }

    public bool DeleteProduct(int id)
    {
        List<Product> products = _repository.GetAll();
        foreach (Product p in products)
        {
            if (p.Id == id)
            {
                products.Remove(p);
                _repository.SaveAll(products);
                return true;
            }
        }
        return false;
    }
}
