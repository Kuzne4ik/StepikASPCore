using Microsoft.AspNetCore.Mvc;

namespace lesson_1_2_1.Controllers
{

    public class ProductsController : Controller
    {

        public ProductsController()
        {

        }

        /// <summary>
        /// Все продукты списком
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Index()
        {
            return "NONE";
        }
        
    }
}
