using System;
using OS.Common.DataAccessHelpers;

namespace OS.Common.AttendanceServices.Interfaces
{
    public interface IASUnitOfWork : IUnitOfWork
    {
        ICheckInRepository ChekInRepository { get; }
    }
}