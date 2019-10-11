using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interface.Services;

namespace WebStore.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly ICartService _cartService;

        public Cart(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
           return View(_cartService.TransformCart());
        }
    }
}
