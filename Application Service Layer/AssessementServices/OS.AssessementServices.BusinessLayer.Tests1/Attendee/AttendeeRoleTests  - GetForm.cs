﻿using OS.AssessementServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.Interfaces;
using OS.Common.AssessementServices.TransfertObjects;
using System;
using System.Collections.Generic;

//namespace OS.AssessementServices.BusinessLayerTests.Attendee
//{
//    [TestClass]
//    public class AttendeeRole_GetForm
//    {
//        [TestMethod]
//        public void GetForm_Throws_FomrIDInexistant()
//        {
//            //Arrange
//            var moqUnitOfWork = new Mock<IESUnitOfWork>();
//            moqUnitOfWork.Setup(x => x.FormQuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormTO));

//            var moqUserService = new Mock<IUserServiceTemp>();
//            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);


//            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
//            var SessionID = 1;
//            var FormID = 999; //Forms inexistant

//            Assert.ThrowsException<Exception>(() => sut.GetFormById(SessionID, FormID));
//        }

//        [TestMethod]
//        public void GetForm_Throws_SessionIDInexistant()
//        {
//            //Arrange
//            var moqUnitOfWork = new Mock<IESUnitOfWork>();
//            moqUnitOfWork.Setup(x => x.FormQuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormTO));
//            var moqUserService = new Mock<IUserServiceTemp>();
//            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => false);

//            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
//            var SessionID = 999999999;//session inexistant
//            var FormID = 1;

//            Assert.ThrowsException<Exception>(() => sut.GetFormById(SessionID, FormID));
//        }

//        [TestMethod]
//        public void GetFormById_ReturnForm_WhenValidParametersIsProvided()
//        {
//            //Arrange
//            var moqUnitOfWork = new Mock<IESUnitOfWork>();

//            var forms = new List<FormTO>();
//            forms.Add(new FormTO { Id = 1 });
//            forms.Add(new FormTO { Id = 2 });

//            moqUnitOfWork.Setup(x => x.FormQuestionRepository.GetAll()).Returns(forms);

//            moqUnitOfWork.Setup(x => x.FormQuestionRepository.GetById(It.IsAny<int>())).Returns(new FormTO { Id = 1 });

//            var moqUserService = new Mock<IUserServiceTemp>();
//            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(true);

//            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
//            var SessionID = 1;
//            var FormID = 1; //Forms inexistant


//            //ACT
//            var FormToAssert = sut.GetFormById(SessionID, FormID);

//            //ASSERT
//            moqUnitOfWork.Verify(u => u.FormQuestionRepository.GetById(It.IsAny<int>()), Times.Once);
//            Assert.AreEqual(FormID, FormToAssert.Id);
//        }
//    }
//}
