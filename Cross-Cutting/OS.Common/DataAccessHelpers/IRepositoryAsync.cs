﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace OS.Common.DataAccessHelpers
{
    public interface IRepositoryAsync<TType, TTypeId>
        where TType : class
    {
        Task<List<TType>> FindAll();
        Task<TType> FindById(TTypeId id);
        Task CreateAsync(TType entity);
        Task UpdateAsync(TType entity);
        Task DeleteAsync(TType entity);

        Task SaveChangesAsync();
    }
}
