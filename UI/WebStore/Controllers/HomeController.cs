using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Filters;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        private readonly List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo
            {
                NameShopper ="E-Shopper Inc.",
                Adress="935 W. Webster Ave New Streets Chicago,",
                Adress2="IL 60614, NY",
                Adress3="Newyork USA",
                Mobile="+2346 17 38 93",
                Fax="1-714-252-0026",
                Email="info@e-shopper.com"
            }
        };

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyNotFound()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View(contacts);
        }
    }
}