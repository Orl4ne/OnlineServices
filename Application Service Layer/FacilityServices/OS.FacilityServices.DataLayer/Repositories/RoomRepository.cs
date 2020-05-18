﻿using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OS.Common.FacilityServices.Interfaces.Repositories;
using OS.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.DataLayer.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private FacilityContext facilityContext;

        public RoomRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public RoomTO Add(RoomTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            var roomEf = Entity.ToEF();
            roomEf.Floor = facilityContext.Floors.First(x => x.Id == Entity.Floor.Id && x.Archived != true);

            return facilityContext.Rooms.Add(roomEf).Entity.ToTransfertObject();
        }

        public IEnumerable<RoomTO> GetAll()
        {
            return facilityContext.Rooms
                .Include(r => r.Floor)
                .Include(r => r.RoomComponents)
                .Where(r => r.Archived != true)
                .Select(r => r.ToTransfertObject());
        }

        public RoomTO GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("The ID isn't in the correct format!");
            }

            return facilityContext.Rooms
                .AsNoTracking()
                .Include(r => r.Floor)
                .Include(r => r.RoomComponents)
                .FirstOrDefault(r => r.Id == Id && r.Archived != true)
                .ToTransfertObject();
        }

        public List<RoomTO> GetRoomsByFloor(int floorId)
        {
            var floorEF = facilityContext.Floors.FirstOrDefault(x => x.Id == floorId && !x.Archived);

            if (floorEF is null)
            {
                throw new KeyNotFoundException($"GetRoomsByFloor: no floor found with ID={floorId}");
            }

            return facilityContext.Rooms
                .Include(r => r.Floor)
                .Where(r => r.Floor.Id == floorId && !r.Archived)
                .Select(r => r.ToTransfertObject())
                .ToList();
        }

        public bool Remove(RoomTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entityEF = facilityContext.Rooms.FirstOrDefault(x => x.Id == entity.Id && !x.Archived);

            if (entityEF is null)
            {
                throw new KeyNotFoundException($"No room found with ID={entity.Id}");
            }

            entityEF.Archived = true;
            var tracking = facilityContext.Rooms.Update(entityEF);
            return tracking.Entity.Archived;
        }

        public bool Remove(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("The ID isn't in the correct format!");
            }

            return Remove(GetById(Id));
        }

        public RoomTO Update(RoomTO Entity)
        {
            if (Entity is null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            var attachedRoom = facilityContext.Rooms.FirstOrDefault(x => x.Id == Entity.Id && x.Archived != true);

            if (attachedRoom != default)
            {
                attachedRoom.UpdateFromDetached(Entity.ToEF());
            }

            if (!facilityContext.Rooms.Any(x => x.Id == Entity.Id))
            {
                throw new KeyNotFoundException("No room found !");
            }

            var tracking = facilityContext.Rooms.Update(attachedRoom);
            tracking.State = EntityState.Detached;
            //var entity = facilityContext.Rooms.Update(attachedRoom).Entity.ToTransfertObject();
            //facilityContext.SaveChanges();
            return tracking.Entity.ToTransfertObject();
        }
    }
}