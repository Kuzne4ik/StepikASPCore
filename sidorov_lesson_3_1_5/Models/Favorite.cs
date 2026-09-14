namespace lesson_3_1_5.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public Favorite(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
