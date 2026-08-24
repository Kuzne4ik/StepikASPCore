using lesson_1_2_2.Models;

namespace lesson2_1.Repositories
{
    public class ProductsRepository
    {
        readonly List<Product>? _products;

        internal ProductsRepository()
        {
            var productsFilePath = Path.Combine(Environment.CurrentDirectory, "data", "products.json");

            if (!File.Exists(productsFilePath))
            {
                throw new Exception($"Файл JSON товарами не найден по пути: {productsFilePath}");
            }

            var productsJson = File.ReadAllText(productsFilePath);


            _products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productsJson);
        }

        public List<Product>? GetAll()
        {
            return _products;
        }

        public Product? TryGetById(int id)
        {
            return _products?.FirstOrDefault(t => t.Id == id);
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        