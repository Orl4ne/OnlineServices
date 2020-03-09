using OS.Common.AttendanceServices.TransfertObjects;
using OS.Common.DataAccessHelpers;
using System.Collections.Generic;

namespace OS.Common.AttendanceServices.Interfaces
{
    public interface ICheckInRepository
    {
        CheckInTO Add(CheckInTO Entity);
        List<CheckInTO> GetCheckInsInSession(int SessionId);
        List<CheckInTO> GetAttendeeCheckIns(int AttendeeId);
    }
}