using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Interface.Api;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class WebApiTestControllerTests
    {
        private WebApiTestController _controller;

        private string[] _expectedValue = new[] { "1", "2", "3" };

        [TestInitialize]
        public void Initialize()
        {
            var value_service_mock = new Mock<IValueService>();



            value_service_mock
                .Setup(Services => Services.GetAsync())
                .ReturnsAsync(_expectedValue);

            _controller = new WebApiTestController( value_service_mock.Object);
        }

        [TestMethod]
        public async Task Index_Metod_Returns_View_With_Values()
        {
            var result = await _controller.Index();

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(view_result.Model);

            Assert.Equal(_expectedValue.Length, model.Count());
        }
    }
}
