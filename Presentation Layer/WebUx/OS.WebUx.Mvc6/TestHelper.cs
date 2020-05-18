using Microsoft.Extensions.Logging;
using Moq;
using OS.Common.RegistrationServices;
using OS.WebUx.Mvc6.Controllers;
using Serilog;
using System;

namespace OS.WebUx.Mvc6
{
    public static class TestHelper
    {
        public static IRSAssistantRole MockIRSServiceRole()
        {
            // REVIEW ILogger a;

            var mockILogger = new Mock<IRSAssistantRole>();

            // mockILogger.Setup(x => x.);

            return mockILogger.Object;
        }
    }
}