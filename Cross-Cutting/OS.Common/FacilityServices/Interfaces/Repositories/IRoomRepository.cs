using OS.Common.DataAccessHelpers;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.FacilityServices.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<RoomTO, int>
    {
        List<RoomTO> GetRoomsByFloor(int floorId);
    }
}
