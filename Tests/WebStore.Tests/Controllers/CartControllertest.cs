using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text;

using Assert = Xunit.Assert;
using WebStore.Controllers;
using WebStore.Interface.Services;
using WebStore.DomainNew.ViewModel;
using System.Security.Claims;
using WebStore.ViewModel;
using WebStore.DomainNew.DTO.Order;
using WebStore.DomainNew.DTO;
using Microsoft.AspNetCore.Http;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class CartControllertest
    {
        [TestMethod]
        public void Checkout_ModelState_Invalid_Retuns_ViewModel()
        {
            var cart_service_mock = new Mock<ICartService>();
            var order_service_moke = new Mock<IOrdersService>();

            var controller = new CartController(cart_service_mock.Object, order_service_moke.Object);

            //устанавливаем состояние модели
            controller.ModelState.AddModelError("error", "InvalidModel");

            const string expected_model_name = "Test order";

            var result = controller.Checkout(new OrderViewModel { Name = expected_model_name });

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<OrderInfo>(view_result.ViewData.Model);

            Assert.Equal(expected_model_name, model.OrderViewModel.Name);
        }

        [TestMethod]
        public void Checkout_Calls_Service_and_return_Redirect()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity
                (
                new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1")
            }));


            var cart_service_mock = new Mock<ICartService>();

            cart_service_mock
                .Setup(p => p.TransformCart())
                .Returns(() => new CartViewModel
                {
                    Items = new Dictionary<ViewModel.ProductViewModel, int>
                    {
                        {new ProductViewModel(), 1}
                    }
                });

            var order_service_mock = new Mock<IOrdersService>();
            order_service_mock
                .Setup(p => p.CreateOrder(It.IsAny<CreateOrderModel>(), It.IsAny<string>()))
                .Returns(new OrderDTO { Id = 1});

            var controller = new CartController(cart_service_mock.Object, order_service_mock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = user
                    }
                }
            };

            var result = controller.Checkout(new OrderViewModel
            {
                Name = "test",
                Address="",
                Phone = ""
            });

            var redirect_result = Assert.IsType<RedirectToActionResult>(result);

            Assert.Null(redirect_result.ControllerName);
            Assert.Equal(nameof(CartController.OrderConfirmed), redirect_result.ActionName);

            Assert.Equal(1, redirect_result.RouteValues["id"]);
        }
    }
}
