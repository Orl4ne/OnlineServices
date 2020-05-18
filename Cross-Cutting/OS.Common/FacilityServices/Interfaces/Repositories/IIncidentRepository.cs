using OS.Common.DataAccessHelpers;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.FacilityServices.Interfaces.Repositories
{
    public interface IIncidentRepository : IRepository<IncidentTO, int>
    {
        List<IncidentTO> GetIncidentsByUserId(int UserId);
        //Est-ce que nous ne rajouterions pas DateTime pour les Incidents, comme ça on pourrait faire un tri par date ? 
    }
}
