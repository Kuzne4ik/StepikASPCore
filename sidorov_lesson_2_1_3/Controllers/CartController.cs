using lesson_2_1_3.Models;
using lesson_2_1_3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_2_1_3.Controllers
{
    public class CartController : Controller
    {
        private readonly CartsRepository _cartsRepository;
        private readonly ProductsRepository _productsRepository;

        public CartController()
        {
            _cartsRepository = new CartsRepository();
            _productsRepository = new ProductsRepository();
        }


        public IActionResult Index(Guid? id)
        {
            Cart cart = null;
            if (id != null)
            {
                // Если передан id, ищем корзину с этим id
                cart = _cartsRepository.TryGetById(id.Value);
            }
            else
            {
                // Получаем корзину по пользователя id (в данном случае, используем константу)
                cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            }
            return View(cart);
        }


        public IActionResult Add(Guid? userId = null, Guid? productId = null)
        {
            // Если передан id, ищем корзину с этим id
            if (userId != null && productId != null)
            {
                var product = _productsRepository.TryGetById(productId.Value);
                if (product == null)
                {
                    return NotFound();
                }

                var cart = _cartsRepository.AddCartItemByUserId(userId.Value, product);

                // Views/Cart/Details.cshtml - для отображения одного товара
                if (cart != null) 
                    return RedirectToAction("Index", new { id = cart.Id});
            }
            throw new NotImplementedException("Cart for null params not implemented");
        }
    }
}
