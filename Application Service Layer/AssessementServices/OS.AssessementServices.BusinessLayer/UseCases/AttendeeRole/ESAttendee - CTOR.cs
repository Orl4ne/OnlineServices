using OS.AssessementServices.DataLayer;
using OS.Common.DataAccessHelpers;
using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.Interfaces;
using OS.Common.AssessementServices.TransfertObjects;
using OS.Common.RegistrationServices;
using OS.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.AssessementServices.BusinessLayer.UseCases
{
    public partial class ESAttendeeRole : IASSAttendeeRole
    {
        private readonly IASSUnitOfWork iESUnitOfWork;
        private readonly IRSAssistantRole iRSAssistantRole;

        // Constructor
        public ESAttendeeRole(IASSUnitOfWork iESUnitOfWork, IRSAssistantRole iRSAssistantRole)
        {
            this.iESUnitOfWork = iESUnitOfWork ?? throw new ArgumentNullException(nameof(iESUnitOfWork));
            this.iRSAssistantRole = iRSAssistantRole ?? throw new ArgumentNullException(nameof(iRSAssistantRole));
        }
    }
}
