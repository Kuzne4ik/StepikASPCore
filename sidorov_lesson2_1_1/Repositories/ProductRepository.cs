using lesson2_1_1.Models;

namespace lesson2_1_1.Repositories
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(1, "Name1", "Desc1"),
            new Product(2, "Name2", "Desc2"),
            new Product(3, "Name3", "Desc3"),
            new Product(4, "Name4", "Desc4"),
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product? TryGetById(int id)
        {
            return products.FirstOrDefault(t => t.Id == id);
        }

    }
}
