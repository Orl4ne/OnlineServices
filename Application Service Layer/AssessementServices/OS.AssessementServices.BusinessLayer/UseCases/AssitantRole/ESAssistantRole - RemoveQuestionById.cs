﻿using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public bool RemoveQuestionById(int questionId)
        {
            var question = GetQuestionById(questionId);

            if (question.Propositions.Count > 0)
            {
                foreach (var proposition in question.Propositions)
                {
                    iESUnitOfWork.QuestionPropositionRepository.Remove(proposition.Id);
                }

                iESUnitOfWork.QuestionRepository.Remove(questionId);

            }
            return iESUnitOfWork.SaveChanges() > 0;
        }
    }
}
