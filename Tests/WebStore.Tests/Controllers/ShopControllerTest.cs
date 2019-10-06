using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.Controllers;
using WebStore.DomainNew.DTO;
using WebStore.DomainNew.Filters;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewComponents;
using WebStore.ViewModel;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class ShopControllerTest
    {
        [TestMethod]
        public void ProductDetails_Return_With_Correct_Item()
        {
            ///A-A-A = Arrange - Act - Assert 
            ///(Подготовка данных - Действие которое выполняется над кодом - проверка утверждениий)

            #region Arrange
            const int expected_id = 1;
            var expected_name = $"Item id {expected_id}";
            var expected_brand_name = $"Brand of item id {expected_id}";
            const decimal expexted_price = 10m;

            var product_data_mock = new Mock<IProductService>();

            product_data_mock
                .Setup(p => p.GetProductById(It.IsAny<int>()))
                .Returns<int>(id => new ProductDTO
                {
                    Id = id,
                    Name = $"Item id {id}",
                    ImageUrl = $"Image_id_{id}.png",
                    Order = 0,
                    Price = expexted_price,
                    SectionId = 1,
                    Brand = new BrandDTO
                    {
                        Id = 1,
                        Name = $"Brand of item id {id}"
                    }
                });
            var controller = new ShopController(product_data_mock.Object);
            #endregion

            #region Act
            var result = controller.ProductDetails(expected_id);
            #endregion

            #region Assert
            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(view_result.Model);

            Assert.Equal(expected_id, model.Id);
            Assert.Equal(expected_name, model.Name);
            Assert.Equal(expexted_price, model.Price);
            Assert.Equal(expected_brand_name, model.BrandName);


            #endregion

        }

        [TestMethod]
        public void ProductDetails_Returns_NotFound()
        {
            var product_data_mock = new Mock<IProductService>();

            product_data_mock
                .Setup(p => p.GetProductById(It.IsAny<int>()))
                .Returns(default(ProductDTO));//пустая ссылка

            var controller = new ShopController(product_data_mock.Object);

            var result = controller.ProductDetails(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [TestMethod]
        public void Product_Returns_Correct_View()
        {
            var product_data_mock = new Mock<IProductService>();
            product_data_mock
                .Setup(p => p.GetProducts(It.IsAny<ProductFilter>()))
                .Returns<ProductFilter>(f => new[]
                {
                    new ProductDTO
                    {
                        Id = 1,
                        Name = "Product 1",
                        Order = 0,
                        Price = 10m,
                        ImageUrl = "Product1.png",
                        Brand = new BrandDTO
                        {
                            Id = 1,
                            Name = "Brand of Product 1"
                        }
                    },
                    new ProductDTO
                    {
                        Id = 2,
                        Name = "Product 2",
                        Order = 1,
                        Price = 20m,
                        ImageUrl = "Product2.png",
                        Brand = new BrandDTO
                        {
                            Id = 2,
                            Name = "Brand of Product 2"
                        }
                    }
                });


            var controller = new ShopController(product_data_mock.Object);

            const int expected_section_id = 1;
            const int expected_brand_id = 1;

            var result = controller.Product(expected_section_id, expected_brand_id);

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CatalogViewModel>(view_result.Model);

            Assert.Equal(2, model.Products.Count());
            Assert.Equal(expected_brand_id, model.BrandId);
            Assert.Equal(expected_section_id, model.SectionId);

            Assert.Equal("Brand of Product 1", model.Products.First().BrandName);
        }
    }
}
