using System;

namespace OS.Common.DataAccessHelpers
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}