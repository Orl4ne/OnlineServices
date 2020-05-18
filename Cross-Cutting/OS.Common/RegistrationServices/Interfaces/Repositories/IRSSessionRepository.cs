using OS.Common.DataAccessHelpers;
using OS.Common.RegistrationServices.TransferObjects;

using System;
using System.Collections.Generic;

namespace OS.Common.RegistrationServices.Interfaces
{
    public interface IRSSessionRepository : IRepository<SessionTO, int>
    {
        IEnumerable<UserTO> GetStudents(SessionTO session);

        IEnumerable<SessionTO> GetByUser(UserTO user);

        IEnumerable<DateTime> GetDates(SessionTO session);

        IEnumerable<SessionTO> GetSessionsByDate(DateTime date);
    }
}