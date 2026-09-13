using lesson_3_1_2.Models;

namespace lesson_3_1_2.Repositories;

public interface IProductsRepository
{
    public List<Product>? GetAll();

    public Product? TryGetById(Guid id);
}