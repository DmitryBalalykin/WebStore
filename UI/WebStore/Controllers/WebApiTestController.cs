using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interface.Api;

namespace WebStore.Controllers
{
    public class WebApiTestController : Controller
    {
        private readonly IValueService _values;

        public WebApiTestController(IValueService values)
        {
            _values = values;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _values.GetAsync();

            return View(values);
        }
    }
}