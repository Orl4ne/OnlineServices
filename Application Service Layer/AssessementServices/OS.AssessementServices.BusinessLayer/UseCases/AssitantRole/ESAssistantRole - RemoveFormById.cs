﻿using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public bool RemoveFormById(int formID)
        {
            var result = iESUnitOfWork.FormRepository.Remove(formID);
            foreach (var item in GetFormById(formID).Questions)
            {
                iESUnitOfWork.QuestionRepository.Remove(item);
                if (item.Propositions.Count>0)
                {
                    foreach (var proposition in item.Propositions)
                    {
                        iESUnitOfWork.QuestionPropositionRepository.Remove(proposition.Id);
                    }
                }
                iESUnitOfWork.QuestionRepository.Remove(item);

            }
            return iESUnitOfWork.SaveChanges()>0;
        }
    }
}
