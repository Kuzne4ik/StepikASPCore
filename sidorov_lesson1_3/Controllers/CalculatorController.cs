using Microsoft.AspNetCore.Mvc;

namespace sidorov_lesson1_3.Controllers
{
    public class CalculatorController : Controller
    {
        public string Index(double arg1, double arg2, string op)
        {
            if (op == "+")
            {
                var sum = arg1 + arg2;
                return arg1 + " " + op + " " + arg2 + " = " + sum;
            }
            if (op == "-")
            {
                var sum = arg1 - arg2;
                return arg1 + " " + op + " " + arg2 + " = " + sum;
            }
            if (op == "*")
            {
                var sum = arg1 * arg2;
                return arg1 + " " + op + " " + arg2 + " = " + sum;
            }

            return $"Неизвестный арифметический оператор: {op}. \nДопустимые значения оператора: +, -, *";
        }
    }
}
