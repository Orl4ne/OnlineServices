using OS.AttendanceServices.BusinessLayer.Domain;
using OS.Common.AttendanceServices;
using OS.Common.AttendanceServices.TransfertObjects;
using OS.Common.Extensions;
using OS.Common.RegistrationServices.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.AttendanceServices.BusinessLayer.UseCases
{
    public partial class ASAttendeeRole : IASAttendeeRole
    {
        public bool CheckIn(CheckInTO checkInArgs)
        {
            if (checkInArgs is null)
                throw new ArgumentNullException(nameof(checkInArgs));

            if (!RegistrationServices.GetUsersBySession(checkInArgs.SessionId).Any(x => x.Id == checkInArgs.AttendeeId))
                throw new Exception("Attendee do not exist in formation");
            if (!RegistrationServices.GetSessionById(checkInArgs.SessionId).SessionDays.Any(x => x.Date.IsSameDate(DateTime.Now)))
                throw new Exception("This session is not held today.");
            if (!checkInArgs.CheckInTime.IsSameDate(DateTime.Now))
                throw new Exception("Attendee is not allowed to check-in other day than the current one.");

            try
            {
                checkInArgs.CheckInTime = DateTime.Now;
                var added = checkInRepository.Add(checkInArgs);
                if (added.Id == Guid.Empty)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
