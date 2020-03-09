using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public bool AddPropositionByQuestion(QuestionPropositionTO propositionTO)
        {
            var result = iESUnitOfWork.QuestionPropositionRepository.Add(propositionTO);
            return iESUnitOfWork.SaveChanges() > 0;
        }
    }
}
