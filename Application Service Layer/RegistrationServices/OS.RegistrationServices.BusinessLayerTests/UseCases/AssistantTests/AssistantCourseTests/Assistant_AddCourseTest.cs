﻿//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OS.Common.Exceptions;
using OS.Common.RegistrationServices.TransferObjects;
using OS.Common.RegistrationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using OS.RegistrationServices.BusinessLayer.UseCase.Assistant;

namespace OS.RegistrationServices.BusinessLayerTests.UseCase.AssistantTests
{
    [TestClass]
    public class Assistant_AddCourseTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSCourseRepository> MockCourseRepository = new Mock<IRSCourseRepository>();

        [TestMethod]
        public void AddCourse_ThrowException_WhenCourseIsNull()
        {
            var ass = new RSAssistantRole(MockUofW.Object );
            //ASSERT
            Assert.ThrowsException<ArgumentNullException>( () => ass.AddCourse(null) );
        }

        [TestMethod]
        public void AddCourse_ThrowException_WhenCourseIDisDiferentThanZero()
        {
            //ARRANGE
            var ass = new RSAssistantRole( new Mock<IRSUnitOfWork>().Object );
            var course = new CourseTO { Id = 100, Name = "Name" };

            //ASSERT
            Assert.ThrowsException<Exception>( () => ass.AddCourse(course)  );
        }

        [TestMethod]
        public void AddCourse_ThrowIsNullOrWhiteSpaceException_WhenCourseNameIsAnEmptyString()
        {
            //ARRANGE
            var ass = new RSAssistantRole(MockUofW.Object);
            var couNameWithWhiteSpace = new CourseTO { Id = 0, Name = " " };
            var couWithNameNull = new CourseTO { Id = 0, Name = null };

            //ASSERT
            Assert.ThrowsException<IsNullOrWhiteSpaceException>( () => ass.AddCourse(couNameWithWhiteSpace) );
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => ass.AddCourse(couWithNameNull));

        }

        [TestMethod]
        public void AddCourse_NewCourse_Test()
        {
            //ARRANGE
            MockCourseRepository.Setup( x => x.Add(It.IsAny<CourseTO>()) );
            MockUofW.Setup( x =>x.CourseRepository ).Returns(MockCourseRepository.Object);

            var ass = new RSAssistantRole(MockUofW.Object);
            var course = new CourseTO { Id = 0, Name = "Name" };

            //ASSERT
            Assert.IsTrue(ass.AddCourse(course));
        }

        [TestMethod]
        public void AddCourse_UserRepositoryIsCalledOnce_WhenAValidCourseIsProvidedAndAddInDB()
        {
            //ARRANGE
            MockCourseRepository.Setup( x => x.Add(It.IsAny<CourseTO>()));
            MockUofW.Setup( x => x.CourseRepository).Returns(MockCourseRepository.Object);

            var ass = new RSAssistantRole(MockUofW.Object);
            var course = new CourseTO { Id = 0, Name = "Name" };

            //ASSERT
            ass.AddCourse(course);
            MockCourseRepository.Verify( x => x.Add(It.IsAny<CourseTO>()), Times.Once );
        }

    }
}
