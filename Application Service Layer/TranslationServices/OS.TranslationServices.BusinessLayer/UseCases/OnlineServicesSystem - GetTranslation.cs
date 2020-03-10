//VERIFIED V3
using OS.Common.Enumerations;
using OS.Common.Exceptions;
using OS.Common.Extensions;
using OS.Common.SecurityServices.Extensions;
using OS.Common.SecurityServices.TransfertObjects;
using OS.Common.TranslationServices.Extensions;
using OS.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class TRSInternalServicesRole
    {
        public MultiLanguageString GetTranslations(ServiceAuthorization APIKey, Tuple<Language, string> TupleToTranslate)
        {
            //CHECKS
            APIKey.IsWellFormed($"API Key is necessary for the translation service to work. {nameof(APIKey)} @ OnlineServicesSystem.IsCorrectTranslation");

            TupleToTranslate.IsValidWithThrow();

            var TranslationTask = Translator.TranslateAsync(TupleToTranslate);
            TranslationTask.Wait();
            var Translated = TranslationTask.Result.ToList();

            //Cleaning the re-traduction of the posted string to avoid loosing the original serquence.
            Translated = Translated.Where(x=>x.Item1 != TupleToTranslate.Item1).ToList();
            Translated.Add(TupleToTranslate);

            //LOGIC HERE
            return new MultiLanguageString(Translated.ToArray());
        }
    }
}
