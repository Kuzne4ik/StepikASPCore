using lesson_3_1_2.Models;
using lesson_3_1_2.Repositories;

namespace lesson_3_1_2.Repositories
{
    public class CartsRepository: ICartsRepository
    {
        public static List<Cart>? _carts = new List<Cart>();


        internal CartsRepository()
        {
        }

        public List<Cart>? GetAll()
        {
            return _carts;
        }

        public Cart AddCart(Guid userId)
        {
            var cart = _carts?.FirstOrDefault(t => t.UserId == userId);

            // Если корзина для данного пользователя не найдена, создаем новую
            if (cart == null)
            {
                cart = new Cart(Guid.NewGuid(), Constants.UserId); // Используем StartGuid для первой корзины
                _carts?.Add(cart);
            }

            return cart;
        }

        public Cart TryGetByUserId(Guid userId)
        {
            var cart = _carts?.FirstOrDefault(t => t.UserId == userId);
            // Если корзина для данного пользователя не найдена, создаем новую
            if (cart == null)
            {
                cart = AddCart(userId);
            }

            return cart;
        }

        public Cart? TryGetById(Guid id)
        {
            return _carts?.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Cart cart)
        {
            var targetCart = _carts.FirstOrDefault(t => t.Id == cart.Id);
            if (targetCart != null)
            {
                targetCart.Items = targetCart.Items;
                return;
            }
            throw new Exception($"Cart not found by id: {cart.Id}");
            
        }

        public Cart? AddCartItem(Guid id, Product product)
        {
            var cart = TryGetById(id);
            
            if (cart != null)
            {
                var cartItem = cart.Items.FirstOrDefault(t => t.Product.Id == product.Id);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    cart.Items.Add(new CartItem(
                    
                        Guid.NewGuid(),
                        product,
                        1
                    ));
                }

                Update(cart);
                return cart;
            }


            throw new Exception($"Cart not found by id: {id}");
        }

        public Cart? AddCartItemByUserId(Guid userId, Product product)
        {
            var cart = TryGetByUserId(userId);


            var cartItem = cart.Items.FirstOrDefault(t => t.Product.Id == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem(

                    Guid.NewGuid(),
                    product,
                    1
                ));
            }

            Update(cart);
            return cart;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        