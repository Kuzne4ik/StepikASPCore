using lesson_3_1_4.Models;

namespace lesson_3_1_4.Repositories;

public interface IProductsRepository
{
    public List<Product>? GetAll();

    public Product? TryGetById(Guid id);
}