using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRteh.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddArticlesController : ControllerBase
    {

        private static Random rnd = new Random();
        private static List<Articles> art = new List<Articles>();
        private readonly ILogger<AddArticlesController> _logger;

        /// <summary>
        /// Массив для имитацией статей, возможно потом снесу, но для теста пусть будет
        /// </summary>
        /// <remarks>
        /// Кладется в боди при генерации берется рандомный стринг
        /// </remarks>
        /// <returns>
        /// Массив, что блин логично
        /// </returns>
        private static string[] Summaries = new string[]
        {
            "Лето",
            "Жара",
            "Печали",
            "Сон",
            "Работа",
            "Я так скоро новый психологический тест придумаю на основе тестовых заданий",
            "Тестинг",
            "Холобный пот",
            "Отрицание....",
            "...Принятие"
        };

        public AddArticlesController(ILogger<AddArticlesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Добавление статьи
        /// </summary>
        /// <remarks>
        /// Напиши имя и заполнение статьи. Добавил XML документацию, должны отображаться summary нормально
        /// </remarks>
        /// <returns>
        /// IEnumerable в который собственно и запихиваем нашу статью с датой и гуидом плюсом.
        /// </returns>
        [HttpPost]
        public IEnumerable<Articles> AddArticle([FromQuery] string NameArticle, string BodyArticle)
        {
            art.Add(new Articles
            {
                Guid = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(art.Count + 1),
                Name = art.Count + 1.ToString() + " " + NameArticle,
                Body = art.Count + 1.ToString() + " " + BodyArticle + " " + Summaries[rnd.Next(1, 10)]
            });

            return art.AsEnumerable<Articles>().ToArray();
        }

    }
}
