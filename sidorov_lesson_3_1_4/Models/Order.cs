namespace lesson_3_1_4.Models
{
    public class Order
    {
        public Order(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal TotalCost => Items.Sum(item => item.Cost);
    }
}
