﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebStore.DomainNew.ViewModel
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public int ItemsCount => Items?.Sum(x => x.Quantity) ?? 0;
    }
}
