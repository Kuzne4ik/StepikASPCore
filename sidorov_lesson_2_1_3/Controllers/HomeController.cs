using lesson2_1.Repositories;
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

            /*
            // Нет id, выводим все товары
            foreach (var product in products)
            {
                res += $"{product.Id}{Environment.NewLine}{product.Name}{Environment.NewLine}{product.Cost:c}{Environment.NewLine}{Environment.NewLine}";
            }*/

            return View(products);
        }
    }
}
