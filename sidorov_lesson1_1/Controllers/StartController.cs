using Microsoft.AspNetCore.Mvc;

namespace lesson1_1.Controllers
{
    public class StartController : Controller
    {
        public string Index()
        {
            var now = DateTime.Now;

            var nightPeriodStart = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            var nightPeriodEnd = new DateTime(now.Year, now.Month, now.Day, 5, 59, 59);

            var morningPeriodStart = new DateTime(now.Year, now.Month, now.Day, 6, 0, 0);
            var morningPeriodEnd = new DateTime(now.Year, now.Month, now.Day, 11, 59, 59);

            var dayPeriodStart = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);
            var dayPeriodEnd = new DateTime(now.Year, now.Month, now.Day, 17, 59, 59);

            var eveningPeriodStart = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);
            var eveningPeriodEnd = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            if (now >= nightPeriodStart && now <= nightPeriodEnd)
            {
                return "Доброй ночи";
            }
            else if (now >= morningPeriodStart && now <= morningPeriodEnd)
            {
                return "Доброе утро";
            }
            else if (now >= dayPeriodStart && now <= dayPeriodEnd)
            {
                return "Добрый день";
            }
            else if (now >= eveningPeriodStart && now <= eveningPeriodEnd)
            {
                return "Добрый вечер";
            }


            throw new Exception("Неизвестный промежуток времени");
            //return View();
        }
    }
}
