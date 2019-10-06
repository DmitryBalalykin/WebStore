using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Controllers;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [TestInitialize]
        public void Initialize()
        {
            var logger_moq = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(logger_moq.Object);
        }

        [TestCleanup]
        public void Cleanup(){}

        [TestMethod]
        public void Index_Returns_View()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public void ThrowExeption_Trow_ApplicationException()
        {
            _=_controller.ThrowExeption();
        }

        [TestMethod]
        public void MyNotFound_Returns_View()
        {
            var result = _controller.MyNotFound();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ErrorStatus_404_Redirect_to_MyNotFound()
        {
            var result = _controller.ErrorStatus("404");

            var redirect_to_action = Assert.IsType<RedirectToActionResult>(result);

            Assert.Null(redirect_to_action.ControllerName);
            Assert.Equal(nameof(HomeController.MyNotFound), redirect_to_action.ActionName);
        }
    }
}
