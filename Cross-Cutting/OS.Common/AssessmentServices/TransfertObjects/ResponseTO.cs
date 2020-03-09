using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.TransfertObjects;
using OS.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace OS.Common.AssessementServices.TransfertObjects
{
    public class ResponseTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string MultiChoices { get; set; }
        public int Grade { get; set; }
        public QuestionPropositionTO QuestionProposition { get; set; }
        public QuestionTO Question { get; set; }
        public SubmissionTO Submission { get; set; }
        public CommentTO Comment { get; set; }
    }
}