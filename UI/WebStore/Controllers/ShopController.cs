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
                    Price = p.Price,
                    BrandName = p.Brand?.Name ?? String.Empty,

                }).OrderBy(p => p.Order).ToList() //Упорядочили -OrderBy() и привели к списку-ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl =product.ImageUrl,
                Price = product.Price,
                Order = product.Order,
                BrandName = product.Brand?.Name ?? String.Empty,

            });
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}