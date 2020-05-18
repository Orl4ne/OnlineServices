using OS.Common.AttendanceServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace OS.Common.AttendanceServices
{
    public interface IASAssistantRole
    {
        bool SetCheckIn(CheckInTO checkInInfo);
        List<CheckInTO> GetAttendeeCheckIns(int sessionId, int attendeeId);
        List<CheckInTO> GetCheckInsInSession(int sessionId);
    }
}
