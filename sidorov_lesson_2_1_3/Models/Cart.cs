namespace lesson_2_1_3.Models
{
    public class Cart
    {
        public static Guid StartGuid { get; } = Guid.NewGuid();

        public Cart(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalCost => Items.Sum(item => item.Cost);
    }
}
