﻿using OS.Common.DataAccessHelpers;

namespace OS.Common.MealServices.Interfaces
{
    public interface IMSUnitOfWork : IUnitOfWork
    {
        IMealRepository MealRepository { get; }
        ISupplierRepository SupplierRepository { get; }
    }
}