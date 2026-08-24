using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace lesson_1_2_2.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            string relativeUrl = Url.Action("Index", "Product", new { id = 1}, Request.Scheme);

            return $"{relativeUrl}";
        }
    }
}
