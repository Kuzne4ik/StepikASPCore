using lesson2_1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_1_2_2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsRepository _productsRepository;

        public ProductController()
        {
            _productsRepository = new ProductsRepository();
        }


        public string Index(int? id = null)
        {
            var res = string.Empty;
            
            // Если передан id, ищем товар с этим id
            if (id != null)
            {
                var product = _productsRepository.TryGetById(id.Value) ;
                if (product != null)
                {
                    res += $"{product.Id}{Environment.NewLine}{product.Name}{Environment.NewLine}{product.Cost:c}{Environment.NewLine}{product.Description}{Environment.NewLine}{Environment.NewLine}";
                }
                else
                {
                    res += $"Товар с Id = {id} не найден.\n\n";
                }
                return res;
            }

            var products = _productsRepository.GetAll();

            // Нет id, выводим все товары
            foreach (var product in products)
            {
                res += $"{product.Id}{Environment.NewLine}{product.Name}{Environment.NewLine}{product.Cost:c}{Environment.NewLine}{Environment.NewLine}";
            }

            return res;
        }

    }
}
