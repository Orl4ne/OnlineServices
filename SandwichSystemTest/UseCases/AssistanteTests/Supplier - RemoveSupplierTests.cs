﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.UseCases.Assistante;
using SandwichSystem.Shared.Interfaces;
using SandwichSystem.Shared.TransfertObjects;
using System;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_RemoveSupplierTests
    {
        [TestMethod]
        public void RemoveSupplier_ThrowException_WhenSupplierIDisZero()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);
            var SupplierToRemove = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>( () => AssistanteRole.RemoveSupplier(SupplierToRemove));
        }

        [TestMethod]
        public void RemoveSupplier_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => AssistanteRole.RemoveSupplier(null));
        }

        [TestMethod]
        public void RemoveSupplier_ReturnsTrue_WhenAValidSupplierIsProvidedAndRemovedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Remove(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToRemove = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            var ReturnValueToAssert = AssistanteRole.RemoveSupplier(SupplierToRemove);

            Assert.IsTrue(ReturnValueToAssert);
        }

        [TestMethod]
        public void RemoveSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndRemovedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Remove(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToRemove = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            AssistanteRole.RemoveSupplier(SupplierToRemove);

            mockSupplierRepository.Verify(x => x.Remove(It.IsAny<SupplierTO>()), Times.Once);
        }
    }
}
