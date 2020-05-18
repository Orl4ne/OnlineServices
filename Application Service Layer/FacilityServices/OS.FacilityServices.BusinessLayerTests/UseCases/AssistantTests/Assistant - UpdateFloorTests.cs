﻿using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.Common.Exceptions;
using OS.Common.FacilityServices.Interfaces;
using OS.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_UpdateFloorTests
    {
        [TestMethod]
        public void UpdateFloor_ReturnUpdatedFloor()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.FloorRepository.Update(It.IsAny<FloorTO>()))
                          .Returns(new FloorTO { Id = 1, Archived = false, Number = 2 });
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            var floor = new FloorTO { Id = 1, Archived = false, Number = 2 };
            //ACT
            var updatedFloor = sut.UpdateFloor(floor);
            //ASSERT
            mockUnitOfWork.Verify(u => u.FloorRepository.Update(It.IsAny<FloorTO>()), Times.Once);
            Assert.IsNotNull(updatedFloor);
        }

        [TestMethod]
        public void UpdateFloor_NullFloorSubmitted_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateFloor(null));
        }

        [TestMethod]
        public void UpdateFloor_IncorrectFloorID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.UpdateFloor(new FloorTO { Archived = false }));
        }
    }
}