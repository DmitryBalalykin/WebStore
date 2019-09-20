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
    public class ShopController : Controller
    {
        private readonly IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Product(int? brandId, int? sectionId)
        {
            var products = _productService.GetProducts(
                new ProductFilter()
                {
                    SectionId = sectionId,
                    BrandId = brandId
                });

            //Сконвертируем в CatalogViewModel
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = sectionId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                }).OrderBy(p => p.Order).ToList() //Упорядочили -OrderBy() и привели к списку-ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}