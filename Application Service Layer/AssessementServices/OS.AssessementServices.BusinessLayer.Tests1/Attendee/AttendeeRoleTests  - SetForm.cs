﻿using OS.AssessementServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.Common.EvaluationServices;
using OS.Common.AssessementServices.Interfaces;
using System;

//namespace OS.AssessementServices.BusinessLayerTests.Attendee
//{
//    [TestClass]
//    public class AttendeeRole_SetForm
//    {
//        //[TestMethod]

//        //public void SetForm_Throws_FomrIDInexistant()
//        //{
//        //    //Arrange
//        //    var moqUnitOfWork = new Mock<IESUnitOfWork>();
//        //    moqUnitOfWork.Setup(x => x.ResponseRepository.GetByID(It.IsAny<int>())).Returns(() => default(FormResponseTO));

//        //    //var moqRepo = new Mock<IRepositoryTemp<Form, int>>();
//        //    //moqRepo.Setup(x => x.GetByID(It.IsAny<int>())).Returns(() => default(Form));
//        //    var moqUserService = new Mock<IUserServiceTemp>();
//        //    moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);


//        //    var sut = new AttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
//        //    var SessionID = 1;
//        //    var FormID = 999; //Forms inexistant

//        //    Assert.ThrowsException<Exception>(() => sut.GetForm(SessionID, FormID));
//        //}

//        //[TestMethod]
//        //public void GetForm_Throws_SessionIDInexistant()
//        //{
//        //    //Arrange
//        //    var moqUnitOfWork = new Mock<IESUnitOfWork>();
//        //    moqUnitOfWork.Setup(x => x.ResponseRepository.GetByID(It.IsAny<int>())).Returns(() => default(FormResponseTO));
//        //    var moqUserService = new Mock<IUserServiceTemp>();
//        //    moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => false);

//        //    var sut = new AttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
//        //    var SessionID = 999999999;//session inexistant
//        //    var FormID = 1;

//        //    Assert.ThrowsException<Exception>(() => sut.GetForm(SessionID, FormID));
//        //}

//        //[TestMethod]
//        //public void GetForm_ReturnForm_WhenValidParametersIsPRovided()
//        //{
//        //    //Arrange
//        //    var SessionID = 1;
//        //    var FormID = 1; //Forms inexistant

//        //    var moqUnitOfWork = new Mock<IESUnitOfWork>();
//        //    moqUnitOfWork.Setup(x => x.ResponseRepository.GetByID(It.IsAny<int>())).Returns(() => default(FormResponseTO));
//        //    var moqUserService = new Mock<IUserServiceTemp>();
//        //    moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);
           
//        //    var sut = new AttendeeRole(moqUnitOfWork.Object, moqUserService.Object);


//        //    //ACT
//        //    var FormToAssert = sut.GetForm(SessionID, FormID);

//        //    //ASSERT
//        //    Assert.AreEqual(FormID, FormToAssert.Id);
//        //}

//        [TestMethod]
//        public void SetReponse_Form_WhenValidParametersIsProvded()
//        {
//            //ARRANGE
//            var mockUnitOfWork = new Mock<IESUnitOfWork>();
//            var mockUserService = new Mock<IUserServiceTemp>();
//            mockUnitOfWork.Setup(u => u.ResponseRepository.Add(It.IsAny<FormResponseTO>()))
//                          .Returns(new FormResponseTO { Id = 1, Date = DateTime.Now });
//            mockUserService.Setup(u => u.IsExistentSession(It.IsAny<int>()))
//                           .Returns(true);
//            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockUserService.Object);
//            var formResponse = new FormResponseTO { Date = DateTime.Now };
//            //ACT
//            var result = attendee.SetResponse(formResponse);
//            //ASSERT
//            mockUnitOfWork.Verify(u => u.ResponseRepository.Add(It.IsAny<FormResponseTO>()), Times.Once);
//            Assert.IsTrue(result);
//        }
//    }
//}