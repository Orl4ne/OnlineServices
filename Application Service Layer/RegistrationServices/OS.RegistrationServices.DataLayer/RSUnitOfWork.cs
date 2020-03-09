using OS.Common.DataAccessHelpers;
using OS.Common.RegistrationServices.Interfaces;
using OS.RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.RegistrationServices.DataLayer
{
    public class RSUnitOfWork : IRSUnitOfWork
    {
        private readonly RegistrationContext registrationContext;

        public RSUnitOfWork(RegistrationContext context)
        {
            this.registrationContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IRSSessionRepository sessionRepository;

        public IRSSessionRepository SessionRepository
          => sessionRepository ??= new SessionRepository(registrationContext);

        private IRSUserRepository userRepository;

        public IRSUserRepository UserRepository
            => userRepository ??= new UserRepository(registrationContext);

        private IRSCourseRepository courseRepository;

        public IRSCourseRepository CourseRepository
            => courseRepository ??= new CourseRepository(registrationContext);

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    registrationContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public int SaveChanges()
        {
            return registrationContext.SaveChanges();
        }
    }
}