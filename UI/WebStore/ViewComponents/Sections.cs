using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.ViewModel;
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
        public async Task<IViewComponentResult> InvokeAsync(string SectionId)
        {
            var section_id = int.TryParse(SectionId, out var id) ? id : (int?)null;
            var sections = GetSections(section_id, out int? parent_section_id);

            return View(
                new SectionCompleteViewModel
                {
                    _section = sections,
                    currentSectionID = section_id,
                    currentParentSection = parent_section_id
                });
        }

        private List<SectionViewModel> GetSections( int? section_Id, out int? parent_section_id)
        {
            parent_section_id = null;

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
                    if (childCategory.Id == section_Id)
                    {
                        parent_section_id = sectionViewModel.Id;
                    }

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
