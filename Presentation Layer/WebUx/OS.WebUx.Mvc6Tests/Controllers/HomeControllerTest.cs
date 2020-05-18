﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using OS.WebUx.Mvc6;
using OS.WebUx.Mvc6.Controllers;

using Serilog;

namespace OS.WebUx.Mvc6Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            Mock<ILogger<HomeController>> mockILogger = TestHelper.MockILogger();
            HomeController controller = new HomeController(mockILogger.Object);

            // Act

            var result = controller.Index() as ViewResult;


            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Privacy()
        {
            // Arrange
            Mock<ILogger<HomeController>> mockILogger = TestHelper.MockILogger();
            HomeController controller = new HomeController(mockILogger.Object);

            // Act
            var result = controller.Privacy() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewData["Message"]);

        }

        [TestMethod]
        public void Error()
        {
            // Arrange
            Mock<ILogger<HomeController>> mockILogger = TestHelper.MockILogger();
            HomeController controller = new HomeController(mockILogger.Object);

            // Act
            IActionResult result = controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
