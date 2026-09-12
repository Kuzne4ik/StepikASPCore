namespace lesson_3_1_1.Models
{
    public class CartItem
    {
        private int _quantity;

        public CartItem(Guid id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public Product Product { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                Cost = Product.Cost * _quantity;
            }
        }

        public decimal Cost { get; set; }
        
    }
}
