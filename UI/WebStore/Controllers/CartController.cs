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

        /// <summary>
        /// Корзина товаров
        /// </summary>
        /// <returns></returns>
        public IActionResult Cart()
        {
            var model = new OrderInfo
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };

            return View(model);
        }

        /// <summary>
        /// Уменьшить колличество товара
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);

            return RedirectToAction("Cart");
        }

        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <returns></returns>
        public IActionResult RemoveAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Cart");
        }

        /// <summary>
        /// добавить товар в корзину
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCart(id);
            return Redirect(returnUrl);
        }

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Cart");
        }

        /// <summary>
        /// Создание заказов
        /// </summary>
        /// <returns></returns>
        public IActionResult Checkout(OrderViewModel model)
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

        #region AJAX api

        public IActionResult GetCartView() => ViewComponent("Cart");

        public IActionResult AddToCartAJAX(int id)
        {
            _cartService.AddToCart(id);
            return Json(new { id, message = $"Товар id:{id} добавлен в корзину"});
        }

        public IActionResult DecrementFromCartAJAX(int id)
        {
            _cartService.DecrementFromCart(id);
            return Json(new { id, message = $"Колличество товара id:{id} уменьшено" });
        }

        public IActionResult RemoveAllAJAX()
        {
            _cartService.RemoveAll();
            return Json(new { message = "В корзине пусто" });
        }

        public IActionResult RemoveFromCartAJAX(int id)
        {
            _cartService.RemoveFromCart(id);
            return Json(new { id, message = $"Товар id: {id} удален из корзины" });
        }

        #endregion
    }
}