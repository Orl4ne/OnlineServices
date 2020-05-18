using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.Logging
{
    public class OnlineServicesLogger
    {

        public static ILogger LoggerConfigurator()
            => new LoggerConfiguration()
                //.WriteTo.Debug()
                //.WriteTo.ColoredConsole()
                .CreateLogger();
    }
}
