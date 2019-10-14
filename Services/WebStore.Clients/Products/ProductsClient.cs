using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Infrastucture.Interfaces;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductService
    {
        public ProductsClient(IConfiguration configuration) : base(configuration, "api/Product")
        {

        }

        public Brand GetBrandById(int id)
        {
            return Get<Brand>($"{ _ServiceAddress}/brands/{id}");
        }

        public IEnumerable<Brand> GetBrands()
        {
            return Get<List<Brand>>($"{_ServiceAddress}/brands");
        }

        public ProductDTO GetProductById(int id)
        {
            return Get<ProductDTO>($"{_ServiceAddress}/{id}");
        }

        public PagedProductDTO GetProducts(ProductFilter filter)
        {
            return Post(_ServiceAddress, filter)
                .Content
                .ReadAsAsync<PagedProductDTO>()
                .Result;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return Get<List<ProductDTO>>($"{_ServiceAddress}/products");
        }

        public Section GetSectionById(int id)
        {
            return Get<Section>($"{_ServiceAddress}/sections/{id}");
        }

        public IEnumerable<Section> GetSections()
        {
            return Get<List<Section>>($"{_ServiceAddress}/sections");
        }
    }
}
