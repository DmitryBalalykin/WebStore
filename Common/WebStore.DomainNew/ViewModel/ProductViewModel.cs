using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Entities.Base.Interface;

namespace WebStore.ViewModel
{
    public class ProductViewModel : INameEntity, IOrderEntity
    {
        public ProductViewModel()
        {
            CategoryProduct = new List<ProductViewModel>();
            HomeStatus = new List<ProductViewModel>();
            NewStatus = new List<ProductViewModel>();
            SaleStatus = new List<ProductViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string BrandName { get; set; }

        public string SectionName { get; set; }

        /// <summary>
        /// Категория продуктов
        /// </summary>
        public List<ProductViewModel> CategoryProduct { get; set; }

        public ProductViewModel GroupStatus { get; set; }

        /// <summary>
        /// Категория продуктов на домашней страницк
        /// </summary>
        public List<ProductViewModel> HomeStatus { get; set; }

        public List<ProductViewModel> NewStatus { get; set; }

        public List<ProductViewModel> SaleStatus { get; set; }

    }
}
