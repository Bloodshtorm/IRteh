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
    public class SerachArticlesController : ControllerBase
    {
        private readonly ILogger<SerachArticlesController> _logger;

        public SerachArticlesController(ILogger<SerachArticlesController> logger)
        {
            _logger = logger;
        }
        /*
        /// <summary>
        /// Генерация тестового списка статей
        /// </summary>
        /// <remarks>
        /// Немного поиграюсь с метадом
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Articles> SerachArticleFor()
        {
            return art.AsEnumerable<Articles>().ToArray();
        }*/
    }
}
