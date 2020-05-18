﻿using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OS.Common.FacilityServices.Interfaces.Repositories;
using OS.Common.FacilityServices.TransfertObjects;
using OS.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.RoomRepositoryTest
{
    [TestClass]
    public class UpdateRoomsTests
    {
        [TestMethod]
        public void Update_AddARoopmAndChangeItsName_ReturnUpdatedRoom()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);
            IFloorRepository floorRepository = new FloorRepository(context);

            var floor = new FloorTO { Number = 2 };
            var addedFloor1 = floorRepository.Add(floor);
            context.SaveChanges();

            RoomTO room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor1 };
            var added = repository.Add(room);
            context.SaveChanges();
            added.Name = new MultiLanguageString("New Room1", "New Room1", "New Room1");
            var updated = repository.Update(added);
            Assert.AreEqual("New Room1", updated.Name.English);
        }

        [TestMethod]
        public void Update_ThrowException_WhenNullIsSupplied()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);

            Assert.ThrowsException<ArgumentNullException>(() => repository.Update(null));
        }

        [TestMethod]
        public void Update_ThrowException_WhenUnexistingRoomIsSupplied()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);
            var room = new RoomTO { Id = 999 };

            Assert.ThrowsException<KeyNotFoundException>(() => repository.Update(room));
        }
    }
}
