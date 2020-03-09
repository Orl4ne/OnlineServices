using OS.Common.AttendanceServices.TransfertObjects;

using System.Collections.Generic;

namespace OS.Common.AttendanceServices
{
    public interface IASAttendeeRole
    {
        bool CheckIn(CheckInTO checkInArgs);
    }
}
