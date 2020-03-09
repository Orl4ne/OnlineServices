using System;
using System.Collections.Generic;
using System.Text;
using OS.Common.Extensions;
using OS.RegistrationServices.BusinessLayer.Extensions;
using OS.Common.RegistrationServices.Interfaces;
using System.Linq;
using OS.Common.RegistrationServices;
using OS.Common.RegistrationServices.TransferObjects;
using OS.Common.Exceptions;
using OS.RegistrationServices.BusinessLayer.UseCase.Attendee;

namespace OS.RegistrationServices.BusinessLayer.UseCase.Assistant
{
    public partial class RSAssistantRole : RSAttendeeRole, IRSAssistantRole
    {
        private readonly IRSUnitOfWork iRSUnitOfWork;

        public RSAssistantRole(IRSUnitOfWork iRSUnitOfWork)
        {
            this.iRSUnitOfWork = iRSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iRSUnitOfWork));
        }

        public RSAssistantRole()
        {

        }
    }
}
