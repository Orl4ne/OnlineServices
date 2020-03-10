//VERIFIED V3
using OS.Common.Exceptions;
using OS.Common.TranslationServices;
using Serilog;
using System;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class TRSInternalServicesRole : ITRSInternalServicesRole
    {
        private readonly ILogger iLogger;
        private readonly ITRSTranslationService Translator;

        public TRSInternalServicesRole(ILogger logger, ITRSTranslationService Translator)
        {
            this.iLogger = logger ?? throw new LoggedException(new ArgumentNullException($"logger should not be null. {nameof(logger)} @ CTOR in OnlineServicesSystem"));

            this.Translator = Translator ?? throw new LoggedException(new ArgumentNullException($"ITRSTranslationService should not be null. {nameof(Translator)} @ CTOR in OnlineServicesSystem"));
        }
    }
}
