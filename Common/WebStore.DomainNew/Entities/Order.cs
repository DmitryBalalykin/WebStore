using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.Entities
{
    public class Order :NameEntity
    {
        /// <summary>
        /// Телефон заказчика
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес заказа
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Ссылка на коллекцию OrderItem
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
