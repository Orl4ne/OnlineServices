using OS.Common.Enumerations;
using OS.Common.SecurityServices.TransfertObjects;
using OS.Common.TranslationServices.TransfertObjects;

using System;

namespace OS.Common.TranslationServices
{
    public interface ITRSInternalServicesRole
    {
        //TODO Refactorer à Argument Pattern pour reduire redondance dans les checkes d'arguments.
        MultiLanguageString GetTranslations(ServiceAuthorization APIKey, Tuple<Language, string> TupleToTranslate);
        bool IsCorrectTranslation(ServiceAuthorization APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage);
    }
}