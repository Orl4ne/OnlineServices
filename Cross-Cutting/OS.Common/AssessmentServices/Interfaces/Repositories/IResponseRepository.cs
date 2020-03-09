using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.AssessementServices.Interfaces
{
    public interface IResponseRepository : IRepository<ResponseTO, int>
    {
        ResponseTO GetById(int Id);
        bool Remove(ResponseTO entity);
        bool Remove(int Id);
        ResponseTO Update(ResponseTO Entity);
        IEnumerable<ResponseTO> GetAllOfForm(int FormId);
    }
}