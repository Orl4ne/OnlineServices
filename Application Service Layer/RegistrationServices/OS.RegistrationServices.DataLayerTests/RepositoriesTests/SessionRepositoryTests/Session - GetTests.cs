﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OS.Common.RegistrationServices.Enumerations;
using OS.Common.RegistrationServices.Interfaces;
using OS.Common.RegistrationServices.TransferObjects;
using OS.RegistrationServices.DataLayer;
using OS.RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OS.RegistrationServices.DataLayerTests.RepositoriesTests.SessionRepositoryTests
{
    [TestClass]
    public class Session___GetTests
    {
        [TestMethod]
        public void Should_Throw_An_ArgumentException_When_UnxistentId_Provided()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
            .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
            .Options;

            using (var context = new RegistrationContext(options))
            {
                IRSSessionRepository sessionRepository = new SessionRepository(context);
                Assert.ThrowsException<ArgumentException>(() => sessionRepository.GetById(1));
            }
        }

        [TestMethod]
        public void ShouldReturn_2Students()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
            .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
            .Options;

            using (var context = new RegistrationContext(options))
            {
                IRSUserRepository userRepository = new UserRepository(context);
                IRSSessionRepository sessionRepository = new SessionRepository(context);
                IRSCourseRepository courseRepository = new CourseRepository(context);

                var Teacher = new UserTO()
                {
                    //Id = 420,
                    Name = "Christian",
                    Email = "gyssels@fartmail.com",
                    Role = UserRole.Teacher
                };

                var Michou = new UserTO()
                {
                    //Id = 45,
                    Name = "Michou Miraisin",
                    Email = "michou@superbg.caca",
                    Role = UserRole.Attendee
                };

                var Isabelle = new UserTO()
                {
                    //Id = 45,
                    Name = "Isabelle Balkany",
                    Email = "isa@rendlargent.gouv",
                    Role = UserRole.Attendee
                };

                var AddedTeacher = userRepository.Add(Teacher);
                var AddedAttendee = userRepository.Add(Michou);
                var AddedAttendee2 = userRepository.Add(Isabelle);
                context.SaveChanges();

                var SQLCourse = new CourseTO()
                {
                    //Id = 28,
                    Name = "SQL"
                };

                var AddedCourse = courseRepository.Add(SQLCourse);
                context.SaveChanges();

                var SQLSession = new SessionTO()
                {
                    //Id = 1,
                    Attendees = new List<UserTO>()
                {
                    AddedAttendee, AddedAttendee2
                },

                    Course = AddedCourse,
                    Teacher = AddedTeacher,
                };

                var AddedSession = sessionRepository.Add(SQLSession);

                context.SaveChanges();

                Assert.AreEqual(2, sessionRepository.GetStudents(AddedSession).Count());
            }
        }

        [TestMethod]
        public void ShouldReturn_2Dates()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
            .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
            .Options;

            using (var context = new RegistrationContext(options))
            {
                IRSUserRepository userRepository = new UserRepository(context);
                IRSSessionRepository sessionRepository = new SessionRepository(context);
                IRSCourseRepository courseRepository = new CourseRepository(context);

                var Teacher = new UserTO()
                {
                    //Id = 420,
                    Name = "Christian",
                    Email = "gyssels@fartmail.com",
                    Role = UserRole.Teacher
                };

                var Michou = new UserTO()
                {
                    //Id = 45,
                    Name = "Michou Miraisin",
                    Email = "michou@superbg.caca",
                    Role = UserRole.Attendee
                };

                var Isabelle = new UserTO()
                {
                    //Id = 45,
                    Name = "Isabelle Balkany",
                    Email = "isa@rendlargent.gouv",
                    Role = UserRole.Attendee
                };

                var AddedTeacher = userRepository.Add(Teacher);
                var AddedAttendee = userRepository.Add(Michou);
                var AddedAttendee2 = userRepository.Add(Isabelle);
                context.SaveChanges();

                var SQLCourse = new CourseTO()
                {
                    //Id = 28,
                    Name = "SQL"
                };

                var AddedCourse = courseRepository.Add(SQLCourse);
                context.SaveChanges();

                var SQLSession = new SessionTO()
                {
                    Attendees = new List<UserTO>()
                    {
                         AddedAttendee
                    },

                    Course = AddedCourse,

                    Teacher = AddedTeacher,

                    SessionDays = new List<SessionDayTO>()
                    {
                        new SessionDayTO()
                        {
                             Date = new DateTime(2020, 02, 20),
                              PresenceType = SessionPresenceType.MorningAfternoon
                        },

                        new SessionDayTO()
                        {
                            Date = new DateTime(2020,02,21),
                            PresenceType = SessionPresenceType.MorningAfternoon
                        }
                    }
                };

                var addedSession = sessionRepository.Add(SQLSession);
                context.SaveChanges();

                Assert.AreEqual(2, sessionRepository.GetDates(SQLSession).Count());
            }
        }
    }
}