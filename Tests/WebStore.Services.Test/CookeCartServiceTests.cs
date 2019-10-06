using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.DomainNew.ViewModel;
using WebStore.Infrastucture.Implementations;
using WebStore.Infrastucture.Interfaces;
using WebStore.Interface.Services;
using WebStore.ViewModel;
using Assert = Xunit.Assert;

namespace WebStore.Services.Test
{
    [TestClass]
    public class CookeCartServiceTests
    {
        [TestMethod]
        public void Cart_Class_ItemsCount_Returns_Correct_Quantity()
        {
            const int expected_count = 4;
            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem { ProductId = 1, Quantity = 1 },
                    new CartItem { ProductId = 2, Quantity = 3 }
                }
            };
            var result = cart.ItemsCount;

            Assert.Equal(expected_count, result);
        }
        [TestMethod]
        public void CartViewModel_Returns_Correct_ItemCount()
        {
            const int expected_count = 3;
            var cart_view_model = new CartViewModel
            {
                Items = new Dictionary<ProductViewModel, int>
                {
                    {new ProductViewModel{Id=1, Name = "Item 1", Price = 0.5m},1 },
                    {new ProductViewModel{Id=2, Name = "Item 2", Price = 1.5m},2 },
                }
            };

            var result = cart_view_model.ItemsCount;

            Assert.Equal(expected_count, result);
        }

        [TestMethod]
        public void CartService_RemoveFromCart_Remove_Correct_Item()
        {
            const int item_id = 1;

            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem{ProductId = item_id, Quantity = 1},
                    new CartItem{ProductId = 2, Quantity = 3}
                }
            };

            var product_data_mock = new Mock<IProductService>();
            var cart_store_mock = new Mock<ICartStore>();
            cart_store_mock
                .Setup(p => p.Cart)
                .Returns(cart);

            var cart_service = new CartService(product_data_mock.Object, cart_store_mock.Object);

            cart_service.RemoveFromCart(item_id);

            Assert.Single(cart.Items);
            Assert.Equal(2, cart.Items[0].ProductId);
        }
    }
}
