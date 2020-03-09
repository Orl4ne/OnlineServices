using OS.Common.Exceptions;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAttendeeRole
    {
        public List<RoomTO> GetRoomsByFloor(int floorId)
        {
            if (floorId <= 0)
            {
                throw new LoggedException($"Invalid floor ID (ID={floorId})");
            }

            var rooms = unitOfWork.RoomRepository.GetRoomsByFloor(floorId);
            return rooms;
        }
    }
}