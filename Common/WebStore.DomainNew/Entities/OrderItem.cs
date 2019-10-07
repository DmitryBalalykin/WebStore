using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.Entities
{
    public class OrderItem:BaseEntity
    {
        [Column(TypeName = "decimal(18, 2)")]
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
