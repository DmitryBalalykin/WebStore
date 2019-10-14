using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Infrastucture.Interfaces;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/Product")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase,IProductService
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Brands/{id}")]
        public Brand GetBrandById(int id)
        {
            return _productService.GetBrandById(id);
        }

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _productService.GetBrands();
        }

        [HttpGet("{id}"),HttpGet("Get")]
        public ProductDTO GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost,ActionName("Post")]
        public PagedProductDTO GetProducts([FromBody]ProductFilter filter)
        {
            return _productService.GetProducts(filter);
        }

        [HttpGet("products")]
        public IEnumerable<ProductDTO> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("Section/{id}")]
        public Section GetSectionById(int id)
        {
            return _productService.GetSectionById(id);
        }

        [HttpGet("sections")]
        public IEnumerable<Section> GetSections()
        {
            return _productService.GetSections();
        }
    }
}