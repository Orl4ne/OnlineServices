﻿namespace OS.Common.DataAccessHelpers
{
    public interface IEntity<TIdType>
    {
        TIdType Id { get; set; }
    }
}
