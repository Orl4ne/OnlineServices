using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.TransfertObjects;
using OS.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole
    {
        public List<FormTO> GetAllForms()
        {
            return iESUnitOfWork.FormRepository.GetAll().ToList();
        }
    }
}
