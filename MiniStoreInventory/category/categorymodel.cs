namespace ClassStore
{
    internal class CategoryModel
    {
        private string name;
        private string description;

        public CategoryModel(string name, string description)
        {
            this.name = name; this.description = description;
        }

        public override string ToString()
        {
            return name + "," + description;
        }

        public string Display()
        {
            return "name: " + name + " | " + "description: " + description;
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
        public string GetDescription() 
        { 
            return description; 
        }
        public void SetDescription(string value) 
        { 
            description = value; 
        }
    }
}
