using OS.AttendanceServices.BusinessLayer.UseCases;
using OS.AttendanceServices.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using OS.Common.AttendanceServices.Interfaces;
using OS.Common.AttendanceServices.TransfertObjects;
using OS.Common.RegistrationServices;
using OS.Common.RegistrationServices.Enumerations;
using OS.Common.RegistrationServices.TransferObjects;

using System;
using System.Collections.Generic;

namespace OS.AttendanceServices.BusinessLayer.Tests
{
    [TestClass]
    public class ASAttendeeRoleWithAzureStorageTests
    {
        [TestMethod]
        public void CheckIn_True_CorrectInputs_WithAzureRepositoryK()
        {
            var checkInRepository = new CheckInRepository(new AzureStorageCredentials());

            var RegistrationServicesMOCK = new Mock<IRSAssistantRole>();
            RegistrationServicesMOCK.Setup(marge => marge.GetUsersBySession(It.IsAny<int>()))
                .Returns(new List<UserTO> {
                    new UserTO { Id = 1 }
                    , new UserTO { Id =2 }
                    , new UserTO { Id =3}
                    , new UserTO { Id =4}
                });
            RegistrationServicesMOCK.Setup(marge => marge.GetSessionById(It.IsAny<int>()))
                .Returns(new SessionTO
                {
                    Id = 999999999,
                    SessionDays = new List<SessionDayTO>
                    {
                        new SessionDayTO
                        {
                             Id = 1, Date = DateTime.Now, PresenceType = SessionPresenceType.OnceADay
                        }
                    }
                });

            var checkInArgs = new CheckInTO
            {
                SessionId = 999999999,
                AttendeeId = 3,
                CheckInTime = DateTime.Now
            };

            var eleve = new ASAttendeeRole(checkInRepository, RegistrationServicesMOCK.Object);
            var valueToAssert = eleve.CheckIn(checkInArgs);
            Assert.IsTrue(valueToAssert);
        }
    }
}
