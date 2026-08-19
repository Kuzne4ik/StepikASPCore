using Microsoft.AspNetCore.Mvc;

namespace sidorov_lesson1_2.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double arg1, double arg2)
        {
            var sum = arg1 + arg2;
            return arg1 + " + " + arg2 + " = " +  sum;
        }
    }
}
