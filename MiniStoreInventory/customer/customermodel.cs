namespace ClassStore
{
    internal class CustomerModel
    {
        private string name;
        private string phone;
        private string email;

        public CustomerModel(string name, string phone, string email)
        {
            this.name = name;
            this.phone = phone; 
            this.email = email;
        }

        public override string ToString()
        {
            return name + "," + phone + "," + email;
        }

        public string Display()
        {
            return "name: " + name + " | " + "phone: " + phone + " | " + "email: " + email;
        }

        // GETTER returns the property's value.
        // SETTER changes the property's value.
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
        public string GetEmail() 
        {
            return email; 
        }
        public void SetEmail(string value) 
        { 
            email = value; 
        }
    }
}//
