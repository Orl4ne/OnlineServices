using OS.Common.DataAccessHelpers;
using OS.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OS.Common.AssessementServices.TransfertObjects
{
    public class FormTO : IEntity<int>
    {
        public int Id { get; set; }

        public MultiLanguageString Name { get; set; }

        public List<QuestionTO> Questions { get; set; }
    }
}