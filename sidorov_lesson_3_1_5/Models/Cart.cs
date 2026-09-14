namespace lesson_3_1_5.Models
{
    public class Cart
    {
        public Cart(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalCost => Items.Sum(item => item.Cost);
    }
}
