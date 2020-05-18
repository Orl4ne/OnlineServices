﻿using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.Common.Exceptions;
using OS.Common.FacilityServices.Interfaces;
using OS.Common.FacilityServices.TransfertObjects;
using OS.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_RemoveComponentTypeTests
    {
        [TestMethod]
        public void RemoveComponentTypeById_ReturnTrue()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var componentTypes = new List<ComponentTypeTO>
            {
                new ComponentTypeTO{ Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch")},
                new ComponentTypeTO{ Id = 2, Archived = false, Name = new MultiLanguageString("PC", "Ordinanteur", "en deutch")}
            };
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.Update(It.IsAny<ComponentTypeTO>()))
                          .Returns(new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") });
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.GetAll()).Returns(componentTypes);

            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            var componentType = new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") };
            //ACT
            var result = sut.RemoveComponentType(1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.ComponentTypeRepository.Update(It.IsAny<ComponentTypeTO>()), Times.Once);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveComponentType_IncorrectComponentTypeId_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.RemoveComponentType(0));
        }

        [TestMethod]
        public void RemoveComponentType_ComponentTypeDoesntExist_ThrowKeyNotFoundException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var componentTypes = new List<ComponentTypeTO>();
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.GetAll()).Returns(componentTypes);
            var sut = new FSAssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<KeyNotFoundException>(() => sut.RemoveComponentType(1));
        }
    }
}