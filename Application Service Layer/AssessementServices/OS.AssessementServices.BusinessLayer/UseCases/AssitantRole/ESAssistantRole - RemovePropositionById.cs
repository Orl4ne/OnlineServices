﻿using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public bool RemovePropositionById(int propositionId)
        {
            var result = iESUnitOfWork.QuestionPropositionRepository.Remove(propositionId);
            return iESUnitOfWork.SaveChanges()>0;
        }
    }
}
