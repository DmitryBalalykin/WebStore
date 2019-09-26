using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.DomainNew.ViewModel
{
    public class CartItem
    {
        public int ProductId { get; set; }

        /// <summary>
        /// Колличество
        /// </summary>
        public int Quantity { get; set; }
    }
}
