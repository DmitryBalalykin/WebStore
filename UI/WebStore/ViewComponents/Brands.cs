using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.ViewComponents
{
    public class Brands : ViewComponent
    {
        private readonly IProductService _productService;

        public Brands(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = GetBrands();
            return View(brands);
        }

        private IEnumerable<BrandViewModel> GetBrands()
        {
            var brands = _productService.GetBrands();

            return brands.Select(x => new BrandViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Order = x.Order,
                ProductCount = 0
            }).OrderBy(x=>x.Order) //Сортировка по порядку
                .ToList();
        }
    }
}
