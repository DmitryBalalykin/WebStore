using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;

namespace WebStore.Infrastucture.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Получение списка брендов
        /// </summary>
        IEnumerable<Brand> GetBrands();

        /// <summary>
        /// Получение списка секций
        /// </summary>
        IEnumerable<Section> GetSections();

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts (ProductFilter filter);

        /// <summary>
        /// Получение списка продуктов без фильтра
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts();
    }
}
