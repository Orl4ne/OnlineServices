using OS.Common.DataAccessHelpers;
using OS.Common.RegistrationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.RegistrationServices.Interfaces
{
    public interface IRSUnitOfWork : IUnitOfWork
    {
        IRSSessionRepository SessionRepository { get; }
        IRSUserRepository UserRepository { get; }
        IRSCourseRepository CourseRepository { get; }
    }
}