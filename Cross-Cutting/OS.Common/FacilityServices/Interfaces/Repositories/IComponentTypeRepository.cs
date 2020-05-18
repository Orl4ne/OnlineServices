using OS.Common.DataAccessHelpers;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.FacilityServices.Interfaces.Repositories
{
    public interface IComponentTypeRepository : IRepository<ComponentTypeTO, int>
    {
        List<ComponentTypeTO> GetComponentTypesByRoom(int roomId);
    }
}
