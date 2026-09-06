using lesson_2_1_3.Models;

namespace lesson_2_1_3.Repositories
{
    public class CartsRepository
    {
        public static List<Cart>? _carts = new List<Cart>();


        internal CartsRepository()
        {
            if (!_carts.Any())
            {
                // Создаем одну корзину при инициализации репозитория
                AddCart();
            }
        }

        public List<Cart>? GetAll()
        {
            return _carts;
        }

        public Cart AddCart()
        {
            Cart newCart;
            if (!_carts.Any())
                newCart = new Cart(Cart.StartGuid); // Используем StartGuid для первой корзины
            else
                newCart = new Cart(Guid.NewGuid());
            _carts?.Add(newCart);

            return newCart;
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
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        