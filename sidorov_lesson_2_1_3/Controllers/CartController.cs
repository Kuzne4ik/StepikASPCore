using lesson2_1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_2_1_3.Controllers
{
    public class CartController : Controller
    {
        private readonly CartsRepository _cartsRepository;

        public CartController()
        {
            _cartsRepository = new CartsRepository();
        }


        public IActionResult Index(int? id = null)
        {

            // Если передан id, ищем товар с этим id и показать view с этим товаром
            if (id != null)
            {
                var cart = _cartsRepository.TryGetById(id.Value) ;

                // Views/Cart/Details.cshtml - для отображения одного товара
                return View(cart);
            }

            throw new NotImplementedException("Carts View not implemented");
        }

    }
}
