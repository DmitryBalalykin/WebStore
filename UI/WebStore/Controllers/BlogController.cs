using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult BlogList()
        {
            _logger.LogInformation("Запросблога");
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }
    }
}