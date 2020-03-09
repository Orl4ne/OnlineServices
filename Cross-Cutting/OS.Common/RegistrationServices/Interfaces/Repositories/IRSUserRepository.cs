using OS.Common.DataAccessHelpers;
using OS.Common.RegistrationServices.TransferObjects;

using System.Collections.Generic;

namespace OS.Common.RegistrationServices.Interfaces
{
    public interface IRSUserRepository : IRepository<UserTO, int>
    {
        IEnumerable<UserTO> GetUserByRole(UserRole role);

        IEnumerable<UserTO> GetUsersBySession(SessionTO session);

        bool IsInSession(UserTO user, SessionTO session);
    }
}