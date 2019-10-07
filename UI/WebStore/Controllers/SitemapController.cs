using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using WebStore.DomainNew.Filters;
using WebStore.Infrastucture.Interfaces;

namespace WebStore.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IProductService _productService;

        public SitemapController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Home", "Index")),
                new SitemapNode(Url.Action("Product", "Shop")),
            };

            foreach (var section in _productService.GetSections())
                if (section.ParentId != null)
                    nodes.Add(new SitemapNode(Url.Action("Shop", "Product", new { SectionId = section.Id })));

            foreach (var brand in _productService.GetBrands())
                nodes.Add(new SitemapNode(Url.Action("Shop", "Product", new { BrandId = brand.Id })));

            foreach (var product in _productService.GetProducts(new ProductFilter()))
                nodes.Add(new SitemapNode(Url.Action("ProductDetails", "Product", new { product.Id })));

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}