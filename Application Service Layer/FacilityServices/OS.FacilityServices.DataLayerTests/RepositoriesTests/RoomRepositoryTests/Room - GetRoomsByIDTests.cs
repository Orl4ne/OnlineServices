﻿using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OS.Common.FacilityServices.Interfaces.Repositories;
using OS.Common.FacilityServices.TransfertObjects;
using OS.Common.TranslationServices.TransfertObjects;
using System;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.RoomRepositoryTest
{
    [TestClass]
    public class GetRoomsByIDTests
    {
        [TestMethod]
        public void GetByID_AddNewRoomAndRetrieveTheAddedRoom_ReturnTheCoorectRoom()
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
            var result = repository.Add(room);
            context.SaveChanges();

            var retrievedRoom = repository.GetById(result.Id);

            Assert.IsNotNull(retrievedRoom);
            Assert.AreEqual(retrievedRoom.ToString(), result.ToString());
        }

        [TestMethod]
        public void GetByID_ThrowException_WhenInvalidIdIsSupplied()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);

            Assert.ThrowsException<ArgumentException>(() => repository.GetById(0));
            Assert.ThrowsException<ArgumentException>(() => repository.GetById(-1));
        }
    }
}
