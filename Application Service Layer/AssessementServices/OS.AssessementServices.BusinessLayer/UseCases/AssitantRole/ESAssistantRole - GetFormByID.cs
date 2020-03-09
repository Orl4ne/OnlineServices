using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public FormTO GetFormById(int formID)
        {
            return iESUnitOfWork.FormRepository.GetById(formID);
        }
    }
}
