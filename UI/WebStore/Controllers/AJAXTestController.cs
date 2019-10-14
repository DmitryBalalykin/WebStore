using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class AJAXTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetJSON (int? id, string msg)
        {
            await Task.Delay(2000);

            return Json(new
            {
                Message = $"Response ({id ?? -1}): {msg ?? "<null>"}",
                serverTime = DateTime.Now
            });
        }

        public async Task<IActionResult> GetTestView()
        {
            await Task.Delay(2000);

            return PartialView("Partial/_DataView", DateTime.Now);
        }
    }
}