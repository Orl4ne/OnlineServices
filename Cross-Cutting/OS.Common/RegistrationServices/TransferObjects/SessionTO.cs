using OS.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;

namespace OS.Common.RegistrationServices.TransferObjects
{
    public class SessionTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public UserTO Teacher { get; set; }
        public CourseTO Course { get; set; }
        public List<SessionDayTO> SessionDays { get; set; } = new List<SessionDayTO>();
        public List<UserTO> Attendees { get; set; } = new List<UserTO>();
    }
}