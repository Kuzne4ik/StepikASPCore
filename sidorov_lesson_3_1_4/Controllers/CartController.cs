using lesson_3_1_4.Models;
using lesson_3_1_4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_4.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;

        public CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
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

        public IActionResult Remove(Guid? userId = null, Guid? productId = null)
        {
            // Если передан id, ищем корзину с этим id
            if (userId != null && productId != null)
            {
                var product = _productsRepository.TryGetById(productId.Value);
                if (product == null)
                {
                    return NotFound();
                }

                var cart = _cartsRepository.RemoveCartItemByUserId(userId.Value, product);

                // Views/Cart/Details.cshtml - для отображения одного товара
                if (cart != null)
                    return RedirectToAction("Index", new { id = cart.Id });
            }
            throw new NotImplementedException("Cart for null params not implemented");
        }

        public IActionResult Clear(Guid? userId = null)
        {
            // Если передан id, ищем корзину с этим id
            if (userId != null)
            {
                var cart = _cartsRepository.Clear(userId.Value);

                // Views/Cart/Details.cshtml - для отображения одного товара
                if (cart != null)
                    return RedirectToAction("Index", new { id = cart.Id });
            }
            throw new NotImplementedException("Cart for null params not implemented");
        }
    }
}
