public class Product
{
    public int Id;
    public string Name;
    public int Price;
    public int Quantity;
    public Product() { }

    public Product(int id, string name, int price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Id},{Name},{Price},{Quantity}";
    }
}
