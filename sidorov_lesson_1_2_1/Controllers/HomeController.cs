using lesson_1_2_1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_1_2_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository _productsRepository;

        public HomeController()
        {
            _productsRepository = new ProductsRepository();
        }

        public string Index()
        {

            var products = _productsRepository.GetAll();

            var res = "";

            foreach (var product in products)
            {
                res += $"{product.Id}{Environment.NewLine}{product.Name}{ Environment.NewLine}{product.Cost:c}{Environment.NewLine}{Environment.NewLine}";
            }

            return res;
        }
    }
}
