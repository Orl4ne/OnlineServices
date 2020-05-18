using OS.Common.RegistrationServices.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.RegistrationServices
{
    public interface IRSAttendeeRole
    {
        public SessionTO GetSessionByUserByDate(int userId, DateTime date);

        public int GetIdByMail(string mail);
        public IEnumerable<SessionTO> GetSessionsByDate(DateTime date);
    }
}