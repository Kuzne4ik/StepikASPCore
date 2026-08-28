namespace lesson_2_1_2.Models
{
    public class Cart
    {
        public Cart(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
