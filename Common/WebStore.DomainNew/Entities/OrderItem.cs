using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.Entities
{
    public class OrderItem:BaseEntity
    {
        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Колличество товаров
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Ссылка по продукт
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Ссылка на порядок
        /// </summary>
        public virtual Order Order { get; set; }
    }
}
