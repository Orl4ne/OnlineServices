using OS.Common.DataAccessHelpers;
using OS.Common.RegistrationServices.Enumerations;

using System;

namespace OS.Common.RegistrationServices.TransferObjects
{
    public class SessionDayTO : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public SessionPresenceType PresenceType { get; set; }
    }
}