using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.ViewComponents
{
    public class Products : ViewComponent
    {
        private IProductService _productService;

        public Products(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = GetProducts();
            return View(products);
        }

        private List<ProductViewModel> GetProducts()
        {
            var statusProduct = _productService.GetProducts();

            var mainHomeStatusies = statusProduct.Where(x => x.StatusHome == true);

            var mainNewStatusies = statusProduct.Where(x => x.StatusNew == true);

            var mainSaleStatusies = statusProduct.Where(x => x.StatusSale == true);

            var homeStatus = new List<ProductViewModel>();

            var newStatus = new List<ProductViewModel>();

            var saleStatus = new List<ProductViewModel>();

            foreach (var parentCategory in mainHomeStatusies)
            {
                homeStatus.Add(new ProductViewModel
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ImageUrl = parentCategory.ImageUrl,
                    Price = parentCategory.Price,
                    HomeStatus = homeStatus
                });
            }

            foreach (var parentCategory in mainNewStatusies)
            {
                homeStatus.Add(new ProductViewModel
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ImageUrl = parentCategory.ImageUrl,
                    Price = parentCategory.Price,
                    NewStatus = homeStatus
                });
            }

            foreach (var parentCategory in mainSaleStatusies)
            {
                homeStatus.Add(new ProductViewModel
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ImageUrl = parentCategory.ImageUrl,
                    Price = parentCategory.Price,
                    SaleStatus = homeStatus
                });
            }
            return homeStatus;
        }
    }
}
