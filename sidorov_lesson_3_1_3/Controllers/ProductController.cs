using lesson_3_1_3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }


        public IActionResult Index(Guid? id = null)
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
