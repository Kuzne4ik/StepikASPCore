using lesson_3_1_5.Models;

namespace lesson_3_1_5.Repositories;

public interface ICartsRepository
{
    public List<Cart>? GetAll();

    public Cart AddCart(Guid userId);

    public Cart TryGetByUserId(Guid userId);

    public Cart? TryGetById(Guid id);

    public void Update(Cart cart);

    public Cart? AddCartItem(Guid id, Product product);

    public Cart? AddCartItemByUserId(Guid userId, Product product);

    public Cart? RemoveCartItemByUserId(Guid userId, Product product);
    public Cart? Clear(Guid userId);
    int GetItemsCount(Guid userId);
}