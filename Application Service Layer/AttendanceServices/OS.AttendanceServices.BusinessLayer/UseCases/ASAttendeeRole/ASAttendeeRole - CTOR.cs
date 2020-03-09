using OS.Common.AttendanceServices.Interfaces;
using OS.Common.RegistrationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.AttendanceServices.BusinessLayer.UseCases
{
    public partial class ASAttendeeRole
    {
        private readonly ICheckInRepository checkInRepository;
        private readonly IRSAssistantRole RegistrationServices;

        public ASAttendeeRole(ICheckInRepository checkInRepository, IRSAssistantRole RegistrationServices)
        {
            this.checkInRepository = checkInRepository ?? throw new ArgumentNullException(nameof(checkInRepository));
            this.RegistrationServices = RegistrationServices;
        }
    }
}
