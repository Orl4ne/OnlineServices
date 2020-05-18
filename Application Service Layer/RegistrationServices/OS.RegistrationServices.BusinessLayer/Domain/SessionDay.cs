using OS.Common.DataAccessHelpers;
using OS.Common.RegistrationServices.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.RegistrationServices.BusinessLayer
{
    public class SessionDay : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public SessionPresenceType PresenceType { get; set; }
    }
}