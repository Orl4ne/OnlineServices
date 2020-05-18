using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.Interfaces;
using OS.Common.AssessementServices.TransfertObjects;
using OS.Common.RegistrationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.AssessementServices.BusinessLayer.UseCases.AssitantRole
{
    public partial class ESAssistantRole : IASSAssistantRole

    {
        private readonly IASSUnitOfWork iESUnitOfWork;
        private readonly IRSAssistantRole iRSAssistantRole;

        //Constructor
        public ESAssistantRole(IASSUnitOfWork iESUnitOfWork, IRSAssistantRole iRSAssistantRole)

        {
            this.iESUnitOfWork = iESUnitOfWork ?? throw new ArgumentNullException(nameof(iESUnitOfWork));
            this.iRSAssistantRole = iRSAssistantRole ?? throw new ArgumentNullException(nameof(iRSAssistantRole));
        }
    }
}