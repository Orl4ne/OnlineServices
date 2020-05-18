﻿using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.Common.FacilityServices.Interfaces;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class Attendee_GetFloorsTests
    {
        [TestMethod]
        public void GetFloors_AddThreeFloorsThenRetrieveThem_ReturnCorrectNumberOfFloors()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var floors = new List<FloorTO>
            {
                new FloorTO { Id = 1, Archived = false},
                new FloorTO{ Id = 2, Archived = false },
                new FloorTO{ Id = 3, Archived = false },
            };
            mockUnitOfWork.Setup(u => u.FloorRepository.GetAll()).Returns(floors);
            var sut = new FSAttendeeRole(mockUnitOfWork.Object);
            //ACT
            var listOfFloors = sut.GetFloors();
            //ASSERT
            mockUnitOfWork.Verify(u => u.FloorRepository.GetAll(), Times.Once);
            Assert.AreEqual(3, listOfFloors.Count);
        }
    }
}