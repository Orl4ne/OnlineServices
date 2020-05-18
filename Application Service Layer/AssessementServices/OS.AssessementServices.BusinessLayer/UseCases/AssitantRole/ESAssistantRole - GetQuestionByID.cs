using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public QuestionTO GetQuestionById(int questionID)
        {
            return iESUnitOfWork.QuestionRepository.GetById(questionID);
        }
    }
}
