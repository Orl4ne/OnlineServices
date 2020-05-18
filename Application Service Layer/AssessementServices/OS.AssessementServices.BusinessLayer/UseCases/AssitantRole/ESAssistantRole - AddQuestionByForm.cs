using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public bool AddQuestionByForm(QuestionTO questionTO)
        {
            var result =  iESUnitOfWork.QuestionRepository.Add(questionTO);
            return iESUnitOfWork.SaveChanges()>0;
        }
    }
}
