using Microsoft.AspNetCore.Mvc;

namespace lesson2_2.Controllers
{
    public class HomeController : Controller
    {
        public string Index(int? id =  null)
        {
            return "HI";
        }
    }
}
