﻿using Newtonsoft.Json;
using OS.Common.Enumerations;
using OS.Common.Exceptions;
using OS.Common.Extensions;
using OS.Common.TranslationServices.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslationServices.DataLayer.ServiceAgents.Extensions
{
    public static class TupleLanguageExtensions
    {
        /// <summary>
        /// This method serialize the text to Azure Cognitive service to be used with the HttpClient request.
        /// </summary>
        /// <param name="TupleText"></param>
        /// <returns></returns>
        public static string ToJsonObject(this Tuple<Language, string> TupleText)
        {
            object[] body = new object[] { new { Text = TupleText.Item2 } };
            return JsonConvert.SerializeObject(body);
        }

        /// <summary>
        /// This method compose the route element of the Azure Cognitive service to be used as part of the URL the HttpClient request.
        /// </summary>
        /// <param name="OriginalText"></param>
        /// <returns></returns>
        public static string ComposeRoute(this Tuple<Language, string> OriginalText)
        {
            //Checks
            OriginalText.IsValidWithThrow();

            var other = OriginalText.Item1.GetOthersValues();
            var ReturnValue = $"&from={OriginalText.Item1.ToAzureLanguage()}&"
                + String.Join("&", OriginalText.Item1.GetOthersValues()
                                    .Distinct()
                                    .Select(x => $"to={x.ToAzureLanguage()}")
                                    );

            return ReturnValue;
        }
    }
}
