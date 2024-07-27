using Microsoft.AspNetCore.Mvc;

namespace lesson2_1_1.Controllers
{
    [Route("api/calc")]
    public class CalculatorController : BaseApiController
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="a">Первое слагаемое</param>
        /// <param name="b">Второе слагаемое</param>
        /// /// <remarks>
        /// Пример запроса: /1/2
        /// </remarks>
        /// <returns></returns>
        [HttpGet("index/{a:int?}/{b:int?}")]
        public string Index2(int a = 0, int b = 0)
        {
            return $"{a} + {b} = {(a + b)}";
        }

        // Как пофиксить ошибку при работе со значением параметра "+": https://stackoverflow.com/questions/56463044/allowdoubleescaping-true-in-iis-express-config-not-working

        /// <summary>
        /// Запрос с разделителями (Sum|Subtract|Multiply)
        /// </summary>
        /// <param name="a">Первый аргумент</param>
        /// <param name="b">Второй аргумент</param>
        /// <param name="c">Оператор (+|-|*)</param>
        /// <remarks>
        /// Пример запроса: /1/2/%2B (%2B - зашфрованный знак +)
        /// </remarks>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("index/{a:int?}/{b:int?}/{c?}")]
        public string Index3( int a = 0, int b = 0, string c = "+")
        {
            if (c != "+" && c != "-" && c != "*" && c != null)
                throw new Exception($"Аргумент 'с' ошибочный!: {c}");


            switch (c)
            {
                case "+": return $"{a} + {b} = {a + b}";
                case "-": return $"{a} - {b} = {a - b}";
                case "*": return $"{a} * {b} = {a * b}";
            }

            return "Можно, только, переедавать операции '+', '-', '*'";
        }

        /// <summary>
        /// Запрос с параметрами
        /// </summary>
        /// <param name="a">Первый аргумент</param>
        /// <param name="b">Второй аргумент</param>
        /// <param name="c">Оператор (+|-|*|/)</param>
        /// <remarks>
        /// Пример запроса: "index?a=1&b=2&c=%2B" (%2B - зашфрованный знак +)
        /// </remarks>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("index")]
        public string Index4([FromQuery]double a = 0, double b = 0, string c = "+")
        {
            if (c != "+" && c != "-" && c != "*" && c != null && c != "/")
                throw new Exception($"Аргумент 'с' ошибочный!: {c}");


            switch (c)
            {
                case "+": return $"{a} + {b} = {a + b}";
                case "-": return $"{a} - {b} = {a - b}";
                case "*": return $"{a} * {b} = {a * b}";
                case "/": return b != 0 ? $"{a} / {b} = {(double)a / (double)b}" : "Делить на ноль нельзя";
            }

            return "Можно, только, переедавать операции '+', '-', '*'";
        }

    }
}
