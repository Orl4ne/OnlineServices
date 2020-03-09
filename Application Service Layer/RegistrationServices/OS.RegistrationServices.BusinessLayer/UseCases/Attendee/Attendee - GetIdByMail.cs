using OS.Common.Exceptions;
using OS.Common.RegistrationServices;
using OS.Common.RegistrationServices.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.RegistrationServices.BusinessLayer.UseCase.Attendee
{
    public partial class RSAttendeeRole : IRSAttendeeRole
    {
        public int GetIdByMail(string mail)
        {
            try
            {
                var user = iRSUnitOfWork.UserRepository.GetAll().First(u=>u.Email == mail);
                return user.Id;
            }
            catch
            {
                throw new LoggedException($"Cannot found this Email (Email={mail})");
            }
        }
    }
}
