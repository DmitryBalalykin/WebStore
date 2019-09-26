using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.Entities.Base;

namespace WebStore.DomainNew.ViewModel
{
    public class UserOrderViewModel:BaseEntity
    {

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public decimal TotalSum { get; set; }
    }
}
