﻿using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.Common.Exceptions;
using OS.Common.FacilityServices.Interfaces;
using OS.Common.FacilityServices.TransfertObjects;
using OS.Common.TranslationServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_UpdateComponentTypeTests
    {
        [TestMethod]
        public void UpdateComponentType_ChangeComponentTypeArchivedProp_ReturnUpdatedComponentType()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.Update(It.IsAny<ComponentTypeTO>()))
                          .Returns(new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") });
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            var componentType = new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") };
            //ACT
            var updatedComponentType = sut.UpdateComponentType(componentType);
            //ASSERT
            mockUnitOfWork.Verify(u => u.ComponentTypeRepository.Update(It.IsAny<ComponentTypeTO>()), Times.Once);
            Assert.IsNotNull(updatedComponentType);
        }

        [TestMethod]
        public void UpdateComponentType_NullComponentType_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateComponentType(null));
        }

        [TestMethod]
        public void UpdateComponentType_IncorrectComponentTypeID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.UpdateComponentType(new ComponentTypeTO { Archived = false }));
        }
    }
}