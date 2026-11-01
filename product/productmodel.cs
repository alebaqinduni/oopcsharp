namespace ClassStore
{
    internal class ProductModel
    {
    private string name;
    private string description;
    private float purchasePrice;
    private float salePrice;
    private float discount;

        public ProductModel(string name, string description, float purchasePrice, float salePrice, float discount)
        {
            this.name = name;
            this.description = description;
            this.purchasePrice = purchasePrice;
            this.salePrice = salePrice;
            this.discount = discount;
        }

        public override string ToString()
        {
            return name + "," + description + "," + purchasePrice + "," + salePrice + "," + discount;
        }

        public string Display()
        {
            return "name: " + name + " | " + "description: " + description + " | " + "purchasePrice: " + purchasePrice + " | " + "salePrice: " + salePrice + " | " + "discount: " + discount;
        }

        // GETTER returns the property's value.
        // SETTER changes the property's value.
        public string GetName()
        { 
            return name;
        }
        public void SetName(string name)
        {
            this.name = name; 
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetDescription()
        { 
            return this.description;
        }
        public void SetPurchasePrice(float purchasePrice)
        {
            this.purchasePrice = purchasePrice;
        }
        public float GetPurchasePrice() 
        { 
            return this.purchasePrice;
        }
        public void SetSalePrice(float salePrice)
        {
            this.salePrice = salePrice;
        }
        public float GetSalePrice() 
        { 
            return this.salePrice - this.discount;
        }
        public void SetDiscount(float discount)
        {
            this.discount = discount;
        }
        public float GetDiscount() 
        { 
            return this.discount; 
        }

    }
}





