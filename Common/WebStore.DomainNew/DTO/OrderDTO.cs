using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO.Order;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.DTO
{
    public class OrderDTO:NameEntity
    {
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Перечисление элементов заказа
        /// </summary>
        public IEnumerable<OrderItemDTO> orderItems { get; set; }

    }
}
