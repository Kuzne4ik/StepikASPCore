using lesson2_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson2_1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var productsFilePath = Path.Combine(Environment.CurrentDirectory, "data", "products.json");

            if (!System.IO.File.Exists(productsFilePath))
            {
                return $"Файл JSON товарами не ннайден по пути: {productsFilePath}";

            }

            var productsJson = System.IO.File.ReadAllText(productsFilePath);

            var products = System.Text.Json.JsonSerializer.Deserialize<Product[] >(productsJson);

            var res = "";

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
