using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.DTO;
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
        /// Возвращает секцию с указанныи индификатором
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Section GetSectionById(int id);

        /// <summary>
        /// Возвращает бренды с указанным индификатором
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Brand GetBrandById(int id);

        /// <summary>
        /// Получение списка секций
        /// </summary>
        IEnumerable<Section> GetSections();

        /// <summary>
        /// Получение списка продуктов
        /// </summary>
        /// <returns></returns>
        PagedProductDTO GetProducts (ProductFilter filter);

        /// <summary>
        /// Получение списка продуктов без фильтра
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductDTO> GetProducts();

        /// <summary>
        /// Получить товар по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTO GetProductById(int id);
    }
}
