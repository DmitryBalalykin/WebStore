using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Infrastucture.Interfaces;
using WebStore.Services.Map;

namespace WebStore.Infrastucture.Implementations
{
    public class SqlProductService : IProductService
    {
        private readonly WebStoreContext _context;

        public SqlProductService(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public PagedProductDTO GetProducts(ProductFilter filter)
        {
            IQueryable<Product> products = _context.Products;

            if (filter.SectionId != null)//Если фильтр .HesValue-задан
                products = products.Where(x => x.SectionId == filter.SectionId.Value);

            if (filter.BrandId != null)
                products = products.Where(x => x.BrandId == filter.BrandId.Value);

            var total_count = products.Count();

            if (filter?.PageSize != null)
                products = products
                   .Skip((filter.Page - 1) * (int)filter.PageSize)
                   .Take((int)filter.PageSize);

            return new PagedProductDTO {
                Products =products
                .AsEnumerable()
                .Select(ProductMapper.ToDTO),
                TotalCount = total_count
            };

        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Section)
                .AsQueryable();

            return products
                .ToList()
                .Select(ProductMapper.ToDTO);
        }

        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.ToList();
        }

        public ProductDTO GetProductById(int id)
        {
           var p = _context.Products
                .Include(x => x.Brand)
                .Include(x => x.Section)
                .FirstOrDefault(x => x.Id == id);
            return  p.ToDTO();
        }

        public Section GetSectionById(int id)
        {
            return _context.Sections.FirstOrDefault(s => s.Id == id);
        }

        public Brand GetBrandById(int id)
        {
            return _context.Brands.FirstOrDefault(b => b.Id == id);
        }
    }
}
