using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OS.Common.RegistrationServices;
using Moq;
using OS.Common.RegistrationServices.TransferObjects;
using OS.Common.RegistrationServices.Enumerations;
using OS.Common.AttendanceServices.Interfaces;
using OS.Common.AttendanceServices.TransfertObjects;
using OS.Common.AttendanceServices.Interfaces;

namespace OS.WebAPI.Services.Mocks
{
    public static class AttendenceServicesMockHelper
    {
        public static ICheckInRepository CheckInRepositoryObject()
        {
            var presenceRepositoryMOCK = new Mock<ICheckInRepository>();

            presenceRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<CheckInTO>()))
                .Returns(new CheckInTO { Id = Guid.NewGuid() });

            return presenceRepositoryMOCK.Object;
        }


    }
}
