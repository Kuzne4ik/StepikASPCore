using lesson_3_1_5.Models;

namespace lesson_3_1_5.Repositories;

public interface IProductsRepository
{
    public List<Product>? GetAll();

    public Product? TryGetById(Guid id);
}