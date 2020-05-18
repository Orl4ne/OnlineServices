using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.Enumerations;
using OS.Common.TranslationServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OS.AssessementServices.DataLayer.Entities
{
    [Table("Questions")]
    public class QuestionEF : IEntity<int>, IMultiLanguageNameFields
    {
        [Key]
        public int Id { get; set; }
        public FormEF Form { get; set; }
        public QuestionType Type { get; set; }
        public int Position { get; set; }
        public string NameEnglish { get; set;}
        public string NameFrench { get; set;}
        public string NameDutch { get; set; }
        public virtual ICollection<QuestionPropositionEF> Propositions { get; set; }
    }
}