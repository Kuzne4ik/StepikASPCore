namespace lesson_2_1_3.Models
{
    public class CartItem
    {
        private int _quantity;

        public CartItem(int id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public Product Product { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                Price = Product.Cost * _quantity;
            }
        }

        public decimal Price { get; set; }
        
    }
}
