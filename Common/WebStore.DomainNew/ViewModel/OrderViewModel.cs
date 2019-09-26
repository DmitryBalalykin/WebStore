using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.ViewModel
{
    public class OrderViewModel:BaseEntity
    {
        /// <summary>
        /// Имя заказчика
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Телефон заказчика
        /// </summary>
        [Required, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        /// <summary>
        /// Адрес заказчика
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}
