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
    public class BlogControllertests
    {
        private BlogController _controller;

        [TestInitialize]
        public void Initialize()
        {
            var logger_moq = new Mock<ILogger<BlogController>>();
            _controller = new BlogController(logger_moq.Object);
        }

        [TestMethod]
        public void BlogSingle_Returns_View()
        {
            var result = _controller.BlogSingle();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void BlogList_Returns_View()
        {
            var result = _controller.BlogList();
            Assert.IsType<ViewResult>(result);
        }

    }
}
