using Microsoft.AspNetCore.Mvc;

namespace lesson2_1_1.Controllers
{

    public class StartController : BaseApiController
    {

        private readonly ILogger<StartController> _logger;

        public StartController(ILogger<StartController> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello")]
        public Task<string> Hello()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            // "Доброй ночи" Ночь - 0:00 до 05:59
            var nightStart = new TimeSpan(0, 0, 0);
            var nightEnd = new TimeSpan(5, 59, 0);

            // "Доброе утро" Утро - 06:00 до 11:59
            var morningStart = new TimeSpan(6, 0, 0);
            var morningEnd = new TimeSpan(11, 59, 0);

            // "Добрый день" День - 12:00 до 17:59
            var dayStart = new TimeSpan(12, 0, 0);
            var dayEnd = new TimeSpan(17, 59, 0);

            // "Добрый вечер" Вечер - 18:00 до 23:59
            var eveningStart = new TimeSpan(18, 0, 0);
            var eveningEnd = new TimeSpan(23, 59, 0);

            if (now > nightStart && now < nightEnd)
            {
                return Task.FromResult("Доброй ночи");
            }

            if (now > morningStart && now < morningEnd)
            {
                return Task.FromResult("Доброе утро");
            }

            if (now > dayStart && now < dayEnd)
            {
                return Task.FromResult("Добрый день");
            }

            if (now > eveningStart && now < eveningEnd)
            {
                return Task.FromResult("Добрый вечер");
            }

            throw new Exception("Реизвестный промежуток врекмени");
        }
    }
}
