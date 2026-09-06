using lesson_2_1_3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_2_1_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository _productsRepository;
        public HomeController()
        {
            _productsRepository = new ProductsRepository();
        }


        public IActionResult Index()
        {
            var products = _productsRepository.GetAll();
            return View(products);
        }


    }
}
