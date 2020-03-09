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

namespace OS.RegistrationServices.BusinessLayer.UseCase.Attendee
{
    public partial class RSAttendeeRole : IRSAttendeeRole
    {
        private readonly IRSUnitOfWork iRSUnitOfWork;

        public RSAttendeeRole(IRSUnitOfWork iRSUnitOfWork)
        {
            this.iRSUnitOfWork = iRSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iRSUnitOfWork));
        }

        public RSAttendeeRole()
        {
        }
    }
}