﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class Session_GetByStudentTests
    {
        [TestMethod]
        public void Should_Return_1_Session_When_User_Is_Student()
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
                    Name = "SQL"
                };

                var MVCCourse = new CourseTO()
                {
                    Name = "MVC"
                };

                var AddedCourse = courseRepository.Add(SQLCourse);
                var AddedCourse2 = courseRepository.Add(MVCCourse);
                context.SaveChanges();

                var SQLSession = new SessionTO()
                {
                    Attendees = new List<UserTO>()
                    {
                        AddedAttendee
                    },

                    Course = AddedCourse,
                    Teacher = AddedTeacher,
                };

                var MVCSession = new SessionTO()
                {
                    Attendees = new List<UserTO>()
                    {
                        AddedAttendee2
                    },

                    Course = AddedCourse,
                    Teacher = AddedTeacher,
                };

                var AddedSession = sessionRepository.Add(SQLSession);
                var AddedSession2 = sessionRepository.Add(MVCSession);
                context.SaveChanges();

                Assert.AreEqual(1, sessionRepository.GetByUser(AddedAttendee2).Count());
            }
        }

        [TestMethod]
        public void Should_Return_2_Session_When_User_Is_Teacher()
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
                    Name = "SQL"
                };

                var MVCCourse = new CourseTO()
                {
                    Name = "MVC"
                };

                var AddedCourse = courseRepository.Add(SQLCourse);
                var AddedCourse2 = courseRepository.Add(MVCCourse);
                context.SaveChanges();

                var SQLSession = new SessionTO()
                {
                    Attendees = new List<UserTO>()
                    {
                        AddedAttendee
                    },

                    Course = AddedCourse,
                    Teacher = AddedTeacher,
                };

                var MVCSession = new SessionTO()
                {
                    Attendees = new List<UserTO>()
                    {
                        AddedAttendee2
                    },

                    Course = AddedCourse,
                    Teacher = AddedTeacher,
                };

                var AddedSession = sessionRepository.Add(SQLSession);
                var AddedSession2 = sessionRepository.Add(MVCSession);
                context.SaveChanges();

                Assert.AreEqual(2, sessionRepository.GetByUser(AddedTeacher).Count());
            }
        }

        [TestMethod]
        public void Should_Throw_Exception_When_User_Is_Assistant()
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
                    Role = UserRole.Assistant
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

                Assert.ThrowsException<ArgumentException>(() => sessionRepository.GetByUser(AddedAttendee2).Count());
            }
        }
    }
}