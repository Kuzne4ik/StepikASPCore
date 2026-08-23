using lesson2_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson2_2.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int? id = null)
        {
            var productsFilePath = Path.Combine(Environment.CurrentDirectory, "data", "products.json");

            if (!System.IO.File.Exists(productsFilePath))
            {
                return $"Файл JSON товарами не найден по пути: {productsFilePath}";
            }

            var productsJson = System.IO.File.ReadAllText(productsFilePath);

            var products = System.Text.Json.JsonSerializer.Deserialize<Product[]>(productsJson);

            var res = "";

            // Если передан id, ищем товар с этим id
            if (id != null)
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    res += product.Id + "\n" +
                           product.Name + "\n" +
                           product.Cost.ToString() + "\n" +
                           product.Description + "\n\n";
                }
                else
                {
                    res += $"Товар с Id = {id} не найден.\n\n";
                }
                return res;
            }

            // Нет id, выводим все товары
            foreach (var product in products)
            {
                res += product.Id + "\n" +
                       product.Name + "\n" +
                       product.Cost.ToString() + "\n\n";
            }

            return res;
        }

    }
}
