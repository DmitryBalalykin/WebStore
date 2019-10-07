using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.ViewModel.BreadCrumbs;
using WebStore.Infrastucture.Interfaces;

namespace WebStore.ViewComponents
{
    public class BreadCrumbs : ViewComponent
    {
        private readonly IProductService _productService;

        public BreadCrumbs(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(BreadCrumbsType Type, int id, BreadCrumbsType FromType)
        {
            switch (Type)
            {
                default: return View(new BreadCrumbsViewModel[0]);

                case BreadCrumbsType.Section:
                    {
                        var section = _productService.GetSectionById(id);
                        return View(new[]
                        {
                       new BreadCrumbsViewModel
                       {
                            BreadCrumbsType = Type,
                            Id = id.ToString(),
                            Name = section.Name
                       }
                    });
                    }

                case BreadCrumbsType.Brand:
                    {
                        var brand = _productService.GetBrandById(id);
                        return View(new[]
                        {
                        new BreadCrumbsViewModel
                        {
                            BreadCrumbsType = Type,
                            Id = id.ToString(),
                            Name = brand.Name
                        }
                    });
                    }

                case BreadCrumbsType.Product:
                    return View(GetProductBreadCrumbs(id, FromType, Type));
            }
        }

        private IEnumerable<BreadCrumbsViewModel> GetProductBreadCrumbs( int id, BreadCrumbsType FromType, BreadCrumbsType Type)
        {
            var product = _productService.GetProductById(id);
            var crumbs = new List<BreadCrumbsViewModel>();

            if (FromType == BreadCrumbsType.Section)
            {
                crumbs.Add(new BreadCrumbsViewModel
                {
                    BreadCrumbsType =FromType,
                    Id = product.Section.Id.ToString(),
                    Name = product.Name
                });
            }
            else
            {
                crumbs.Add(new BreadCrumbsViewModel
                {
                    BreadCrumbsType = FromType,
                    Id = product.Section.Id.ToString(),
                    Name = product.Name
                });
            }

            crumbs.Add(new BreadCrumbsViewModel
            {
                BreadCrumbsType = Type,
                Id = product.Id.ToString(),
                Name=product.Name
            });

            return crumbs;
        }
    }
}
