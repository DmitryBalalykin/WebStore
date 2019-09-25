using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.DTO.Order;
using WebStore.DomainNew.ViewModel;
using WebStore.Interface.Services;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly ICartService _cartService;

        public CartController(ICartService cartService, IOrdersService ordersService)
        {
            _ordersService = ordersService;
            _cartService = cartService;
        }


        public IActionResult Cart()
        {
            var model = new OrderInfo
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };

            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);

            return RedirectToAction("Cart");
        }

        public IActionResult RemoveAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Cart");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCart(id);
            return Redirect(returnUrl);
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Cart");
        }

        /// <summary>
        /// Создание заказов
        /// </summary>
        /// <returns></returns>
        public IActionResult ChekOut(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var create_order_model = new CreateOrderModel
                {
                    orderModel = model,
                    orderItems = _cartService.TransformCart().Items.Select(item => new OrderItemDTO
                    {
                        Id = item.Key.Id,
                        Price = item.Key.Price,
                        Quantity = item.Value
                    }).ToList()
                };

                var orderResult = _ordersService.CreateOrder(create_order_model, User.Identity.Name);

                _cartService.RemoveAll();
                return RedirectToAction("OrderConfirmed", new { orderResult.Id });
            }

            var detailsModel = new OrderInfo()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = model
            };

            return View("Cart", detailsModel);
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.Order = id;
            return View();
        }
    }
}