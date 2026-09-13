using lesson_3_1_2.Models;

namespace lesson_3_1_2.Repositories;

public interface ICartsRepository
{
    public List<Cart>? GetAll();

    public Cart AddCart(Guid userId);

    public Cart TryGetByUserId(Guid userId);

    public Cart? TryGetById(Guid id);

    public void Update(Cart cart);

    public Cart? AddCartItem(Guid id, Product product);

    public Cart? AddCartItemByUserId(Guid userId, Product product);
}