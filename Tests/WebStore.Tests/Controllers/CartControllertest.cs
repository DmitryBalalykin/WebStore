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
using WebStore.Infrastucture.Interfaces;
using WebStore.Infrastucture.Implementations;
using WebStore.DomainNew.Filters;
using System.Linq;

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

        [TestMethod]
        public void CartController_AddToCart_WorksCorrect()
        {
            var cart = new Cart
            {
                Items = new List<CartItem>()
            };

            var product_data_mock = new Mock<IProductService>();
            var cart_store_mock = new Mock<ICartStore>();

            cart_store_mock
                .Setup(c => c.Cart)
                .Returns(cart);

            var cart_service = new CartService(product_data_mock.Object, cart_store_mock.Object);

            const int expected_id = 5;
            cart_service.AddToCart(expected_id);

            Assert.Equal(1, cart.ItemsCount);
            Assert.Equal(1, cart.Items.Count);
            Assert.Equal(expected_id, cart.Items[0].ProductId);
        }

        [TestMethod]
        public void CartController_RemoveAll_ClearCart()
        {
            const int item_id = 1;
            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem { ProductId = item_id, Quantity = 1 },
                    new CartItem { ProductId = 2, Quantity = 1 }
                }
            };

            var product_data_mock = new Mock<IProductService>();
            var cart_store_mock = new Mock<ICartStore>();
            cart_store_mock
               .Setup(c => c.Cart)
               .Returns(cart);

            var cart_service = new CartService(product_data_mock.Object, cart_store_mock.Object);

            cart_service.RemoveAll();

            Assert.Empty(cart.Items);

        }

        [TestMethod]
        public void CartController_DecrementFromCart_Correct()
        {
            const int item_id = 1;
            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem{ProductId = item_id, Quantity=3},
                    new CartItem{ProductId = 2, Quantity = 5}
                }
            };

            var product_service_mock = new Mock<IProductService>();
            var cart_store_data = new Mock<ICartStore>();
            cart_store_data
                .Setup(p => p.Cart)
                .Returns(cart);

            var cart_service = new CartService(product_service_mock.Object, cart_store_data.Object);

            cart_service.DecrementFromCart(item_id);

            Assert.Equal(7, cart.ItemsCount);
            Assert.Equal(2, cart.Items.Count);
            Assert.Equal(item_id, cart.Items[0].ProductId);
            Assert.Equal(2, cart.Items[0].Quantity);

        }

        [TestMethod]
        public void CartController_RemoveFromCart_Item_When_Decrement()
        {
            const int item_id = 1;

            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem{ProductId = item_id, Quantity=1},
                    new CartItem{ProductId = 2, Quantity = 5}
                }
            };

            var product_service_mock = new Mock<IProductService>();
            var cart_store_mock = new Mock<ICartStore>();
            cart_store_mock
                .Setup(p => p.Cart)
                .Returns(cart);

            var cart_service = new CartService(product_service_mock.Object, cart_store_mock.Object);

            cart_service.DecrementFromCart(item_id);

            Assert.Equal(5, cart.ItemsCount);
            Assert.Single(cart.Items);
        }

        [TestMethod]
        public void CartController_TransformCart_WorksCorrect()
        {
            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem{ProductId = 1, Quantity = 1},
                    new CartItem{ProductId = 2, Quantity = 4}
                }
            };

            var products = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "Product 1",
                    ImageUrl = "Image1.png",
                    Order = 0,
                    Price = 1.1m
                },
                new ProductDTO
                {
                    Id = 2,
                    Name = "Product 2",
                    ImageUrl = "Image2.png",
                    Order =1,
                    Price = 2.2m
                }
            };

            var product_service_mock = new Mock<IProductService>();
            product_service_mock
                .Setup(p => p.GetProducts(It.IsAny<ProductFilter>()))
                .Returns(new PagedProductDTO { Products = products});

            var cart_store_mock = new Mock<ICartStore>();
            cart_store_mock
                .Setup(p => p.Cart)
                .Returns(cart);

            var cart_service = new CartService(product_service_mock.Object, cart_store_mock.Object);

            var result = cart_service.TransformCart();

            Assert.Equal(5, result.ItemsCount);
            Assert.Equal(1.1m, result.Items.First().Key.Price);

        }
    }
}
