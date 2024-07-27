namespace lesson2_1_1.Models
{
    public class Product
    {

        public Product(int id, string name, string description)
        {
            this.Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}
