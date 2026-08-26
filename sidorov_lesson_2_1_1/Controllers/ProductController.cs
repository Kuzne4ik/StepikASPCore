using lesson2_1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_2_1_1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsRepository _productsRepository;

        public ProductController()
        {
            _productsRepository = new ProductsRepository();
        }


        public IActionResult Index(int? id = null)
        {

            // Если передан id, ищем товар с этим id и показать view с этим товаром
            if (id != null)
            {
                var product = _productsRepository.TryGetById(id.Value) ;

                // Views/Product/Details.cshtml - для отображения одного товара
                return View(product);
            }

            // Если id не передан, показать view со всеми товарами
            var products = _productsRepository.GetAll();

            // Views/Product/Index.cshtml - для отображения всех товаров
            return View(products);
        }

    }
}
