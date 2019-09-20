using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Entities;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.ViewComponents
{
    public class Sections : ViewComponent
    {
        private readonly IProductService _productservice;

        public Sections(IProductService productService)
        {
            _productservice = productService;
        }


        /// <summary>
        /// Получение секций списка и приведения их к нужному нам типу
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sections = GetSections();
            return View(sections);
        }

        private List<SectionViewModel> GetSections()
        {
            var categories = _productservice.GetSections();

            var parentCategories = categories.Where(x=> !x.ParentId.HasValue).ToArray();//из всех берем только те у которых ParentId is null

            var parentSection = new List<SectionViewModel>();

            //Получили и заполнели родительские категории
            foreach (var parentCategory in parentCategories)
            {
                parentSection.Add(new SectionViewModel()
                {
                    Id =parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentSection = null
                });
            }

            //Получили и заполнили дочерние категори
            foreach (var sectionViewModel in parentSection)
            {
                var childCategories = categories.Where(c => c.ParentId == sectionViewModel.Id);

                foreach(var childCategory in childCategories)
                {
                    sectionViewModel.ChildSections.Add(new SectionViewModel
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentSection = sectionViewModel
                    });
                }
                sectionViewModel.ChildSections = sectionViewModel.ChildSections.OrderBy(c => c.Order).ToList();
            }
            parentSection = parentSection.OrderBy(c => c.Order).ToList();

            return parentSection;
        }
    }
}
