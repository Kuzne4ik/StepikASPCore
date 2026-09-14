using lesson_3_1_3.Models;

namespace lesson_3_1_3.Repositories;

public interface IProductsRepository
{
    public List<Product>? GetAll();

    public Product? TryGetById(Guid id);
}