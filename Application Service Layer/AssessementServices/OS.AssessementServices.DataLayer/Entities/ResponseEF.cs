using OS.Common.DataAccessHelpers;
using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.Enumerations;
using OS.Common.TranslationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OS.AssessementServices.DataLayer.Entities
{
    [Table("Responses")]
    public class ResponseEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string MultiChoices { get; set; }
        public int Grade { get; set; }
        public QuestionPropositionEF QuestionProposition { get; set; }
        public QuestionEF Question { get; set; }
        public SubmissionEF Submission { get; set; }
        public CommentEF Comment { get; set; }
    }
}