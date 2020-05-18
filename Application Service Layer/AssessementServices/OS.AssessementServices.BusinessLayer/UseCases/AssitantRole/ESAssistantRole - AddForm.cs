using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public bool AddForm(FormTO form)
        {
            iESUnitOfWork.FormRepository.Add(form);
            return iESUnitOfWork.SaveChanges()>0;
            
        }
    }
}
