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


        public IActionResult Index(Guid? id = null)
        {

            // Если передан id, ищем корзину с этим id и показать view с этим товаром
            if (id != null)
            {
                var cart = _cartsRepository.TryGetById(id.Value);

                // Views/Cart/Details.cshtml - для отображения одного товара
                return View(cart);
            }

            throw new NotImplementedException("Carts View not implemented");
        }


        public IActionResult Add(Guid? id = null, Guid? productId = null)
        {
            // Если передан id, ищем корзину с этим id
            if (id != null && productId != null)
            {
                var product = _productsRepository.TryGetById(productId.Value);
                if(product == null)
                {
                    return NotFound();
                }

                var cart = _cartsRepository.AddCartItem(id.Value, product);

                // Views/Cart/Details.cshtml - для отображения одного товара
                if (cart != null) 
                    return RedirectToAction("Index", new { id = cart.Id});
            }
            throw new NotImplementedException("Carts View not implemented");
        }
    }
}
