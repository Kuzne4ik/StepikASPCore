using lesson_3_1_2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository _productsRepository;
        public HomeController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = _productsRepository.GetAll();
            return View(products);
        }


    }
}
