using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.WebUx.Mvc6.Controllers;
using Serilog;
using System;

namespace OS.WebUx.Mvc6Tests
{
    public static class TestHelper
    {
        public static Mock<ILogger<HomeController>> MockILogger()
        {
            // REVIEW ILogger a;

            var mockILogger = new Mock<ILogger<HomeController>>();

            mockILogger.Setup(x => x.LogError(It.IsAny<string>()));
            mockILogger.Setup(x => x.LogError(It.IsAny<Exception>(), It.IsAny<string>()));
            mockILogger.Setup(x => x.LogError(It.IsAny<ArgumentNullException>(), It.IsAny<string>()));
            mockILogger.Setup(x => x.LogError(It.IsAny<ArgumentOutOfRangeException>(), It.IsAny<string>()));

            return mockILogger;
        }
    }
}
