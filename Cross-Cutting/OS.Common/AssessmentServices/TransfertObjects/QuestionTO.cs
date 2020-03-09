using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.Enumerations;
using OS.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OS.Common.AssessementServices.TransfertObjects
{
    public class QuestionTO : IEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public int FormId { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        [Required]
        public int Position { get; set; }
        [Required]
        public MultiLanguageString Libelle { get; set; }
        public List<QuestionPropositionTO> Propositions { get; set; }
    }
}