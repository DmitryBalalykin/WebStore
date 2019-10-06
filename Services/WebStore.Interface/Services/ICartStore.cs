using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.ViewModel;

namespace WebStore.Interface.Services
{
    public interface ICartStore
    {
        Cart Cart { get; set; }
    }
}
