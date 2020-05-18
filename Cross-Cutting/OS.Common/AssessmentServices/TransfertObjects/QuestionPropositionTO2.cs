using OS.Common.DataAccessHelpers;
using OS.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.AssessementServices.TransfertObjects
{
    public class QuestionPropositionTO2 : IEntity<int>
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public MultiLanguageString Libelle { get; set; }
    }
}
