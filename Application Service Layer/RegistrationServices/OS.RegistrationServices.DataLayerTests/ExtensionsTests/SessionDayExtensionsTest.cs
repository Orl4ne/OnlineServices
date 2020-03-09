using Microsoft.VisualStudio.TestTools.UnitTesting;
using OS.Common.RegistrationServices.TransferObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OS.Common.RegistrationServices.Enumerations;
using OS.RegistrationServices.DataLayer.Extensions;

namespace OS.RegistrationServices.DataLayerTests
{
    [TestClass]
    public class SessionDayExtensionsTest
    {
        [TestMethod]
        public void Should_Parse_In_Same_DateTime_Format()
        {
            SessionDayTO sessionDay = new SessionDayTO()
            {
                Id = 1,
                Date = new DateTime(2020, 02, 03),
                PresenceType = SessionPresenceType.MorningOnly
            };

            Assert.AreEqual(sessionDay.Date, sessionDay.ToEF().ToTransfertObject().Date);
        }
    }
}