using lesson_3_1_5.Models;

namespace lesson_3_1_5.Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        readonly List<Product>? _products;

        public ProductsRepository()
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

        public Product? TryGetById(Guid id)
        {
            return _products?.FirstOrDefault(t => t.Id == id);
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        