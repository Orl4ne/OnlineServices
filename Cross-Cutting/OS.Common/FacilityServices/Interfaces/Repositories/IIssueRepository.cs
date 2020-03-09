using OS.Common.DataAccessHelpers;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.FacilityServices.Interfaces.Repositories
{
    public interface IIssueRepository : IRepository<IssueTO, int>
    {
        List<IssueTO> GetIssuesByComponentType(int componentTypeId);
    }
}
