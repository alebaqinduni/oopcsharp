namespace ClassStore
{
    internal class SupplierModel
    {
        private string name;
        private string phone;
        private string company;

        public SupplierModel(string name, string phone, string company)
        {
            this.name = name;
            this.phone = phone; 
            this.company = company;
        }

        public override string ToString()
        {
            return name + "," + phone + "," + company;
        }

        public string Display()
        {
            return "name: " + name + " | " + "phone: " + phone + " | " + "company: " + company;
        }

        // GETTER returns the property's value.
        // SETTER assigns/changes the property's value.
        public string GetName() 
        { 
            return name; 
        }
        public void SetName(string value) 
        { 
            name = value; 
        }
        public string GetPhone() 
        { 
            return phone; 
        }
        public void SetPhone(string value) 
        { 
            phone = value; 
        }
        public string GetCompany() 
        { 
            return company; 
        }
        public void SetCompany(string value) 
        { 
            company = value; 
        }
    }
}
