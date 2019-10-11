using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.DomainNew.Filters;
using WebStore.DomainNew.ViewModel;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public ShopController(IProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
        }

        public IActionResult Product(int? brandId, int? sectionId, int page = 1)
        {
            var page_size = int.Parse(_configuration["PageSize"]);

            var products = _productService.GetProducts(
                new ProductFilter()
                {
                    SectionId = sectionId,
                    BrandId = brandId,
                    Page = page,
                    PageSize = page_size,
                });

            //Сконвертируем в CatalogViewModel
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = sectionId,
                PageViewModel = new PageViewModel
                {
                    PageSize = page_size,
                    PageNumer =page,
                    TotalItes = products.TotalCount
                },
                Products = products.Products.Select(p => new ProductViewModel()
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


    }
}