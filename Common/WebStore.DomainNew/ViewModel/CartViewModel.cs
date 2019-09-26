using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.ViewModel;

namespace WebStore.DomainNew.ViewModel
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; }

        public int ItemsCount => Items?.Sum(x => x.Value) ?? 0;
    }
}
