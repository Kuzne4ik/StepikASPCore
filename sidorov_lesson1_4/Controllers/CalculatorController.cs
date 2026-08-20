using Microsoft.AspNetCore.Mvc;

namespace sidorov_lesson1_4.Controllers
{
    [Route("calc")]
    public class CalculatorController : Controller
    {
        [Route("index")]
        public string Index(double a, double b, string c = "+")
        {
            if (c == "+")
            {
                var sum = a + b;
                return a + " " + c + " " + b + " = " + sum;
            }
            if (c == "-")
            {
                var sum = a - b;
                return a + " " + c + " " + b + " = " + sum;
            }
            if (c == "*")
            {
                var sum = a * b;
                return a + " " + c + " " + b + " = " + sum;
            }
            if (c == "/")
            {
                var sum = a / b;
                return a + " " + c + " " + b + " = " + sum;
            }
            return $"Неизвестный арифметический оператор: {c}. \nДопустимые значения оператора: +, -, *, /";
        }
    }
}
