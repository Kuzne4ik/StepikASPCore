using lesson_3_1_5.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_3_1_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        public HomeController(IProductsRepository productsRepository)
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
