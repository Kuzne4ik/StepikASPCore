namespace lesson_2_1_3.Models
{
    public class CartItem
    {
        public CartItem(int id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        
    }
}
