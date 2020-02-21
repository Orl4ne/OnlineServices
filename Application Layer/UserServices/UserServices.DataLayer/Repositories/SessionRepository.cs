﻿using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;
using RegistrationServices.DataLayer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationServices.DataLayer.Repositories
{
    public class SessionRepository : IRSSessionRepository
    {
        private RegistrationContext registrationContext;

        public SessionRepository(RegistrationContext registrationContext)
        {
            this.registrationContext = registrationContext;
        }

        public SessionTO Add(SessionTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            if (Entity.Id != 0)
            {
                return Entity;
            }

            var sessionEF = Entity.ToEF();
            sessionEF.Course = registrationContext.Courses.FirstOrDefault(x => x.Id == Entity.Course.Id);

            sessionEF.UserSessions = new List<UserSessionEF>();
            var session = registrationContext.Sessions.Add(sessionEF).Entity;

            //TODO 1) userserssion.sessionid= nouvelle sessionid
            //TODO 2) registrationContext.UserSessions.Add

            AddUserSession(Entity, session);

            return sessionEF.ToTransfertObject();
        }

        private void AddUserSession(SessionTO Entity, SessionEF session)
        {
            if ((Entity.Attendees != null) )
            {
                foreach (var user in Entity.Attendees)
                {
                    var userSession = new UserSessionEF()
                    {
                        SessionId = session.Id,
                        Session = session,
                        UserId = user.Id,
                        User = registrationContext.Users.First(x => x.Id == user.Id)
                    };
                    registrationContext.UserSessions.Add(userSession);
                }
            }
            if ((Entity.Teacher != null))
            {
                var teacherEF = new UserSessionEF()
                {
                    SessionId = session.Id,
                    Session = session,
                    UserId = Entity.Teacher.Id,
                    User = registrationContext.Users.First(x => x.Id == Entity.Teacher.Id)
                };

                registrationContext.UserSessions.Add(teacherEF);
            }
        }

        public IEnumerable<SessionTO> GetAll()
            => registrationContext.Sessions
                .AsNoTracking()
                .Include(x => x.UserSessions).ThenInclude(x => x.User)
                .Include(x => x.Dates)
                .Select(x => x.ToTransfertObject())
                .ToList();

        public SessionTO GetById(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException();

            if (!registrationContext.Sessions.Any(x => x.Id == Id))
                throw new ArgumentException($"There is no  session at Id{Id}");

            return registrationContext.Sessions
            .AsNoTracking()
            .Include(x => x.UserSessions).ThenInclude(x => x.User)
            .Include(x => x.Dates)
            .FirstOrDefault(x => x.Id == Id).ToTransfertObject();
        }

        public IEnumerable<DateTime> GetDates(SessionTO session)
            => registrationContext.Sessions
            .AsNoTracking()
            .SelectMany(x => x.Dates.Select(x => x.Date));

        public IEnumerable<UserTO> GetStudents(SessionTO session)
            => registrationContext.UserSessions
                .Where(x => x.User.Role == UserRole.Attendee)
                .Select(x => x.User.ToTransfertObject()).ToList();

        public bool Remove(SessionTO entity)
            => Remove(entity.Id)
;

        public bool Remove(int Id)
        {
            if (!registrationContext.Sessions.Any(x => x.Id == Id))
                throw new ArgumentException($"There is no session at Id {Id}");

            var sessionToDelete = registrationContext.Sessions.FirstOrDefault(x => x.Id == Id);

            try
            {
                registrationContext.Sessions.Remove(sessionToDelete);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public SessionTO Update(SessionTO Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SessionTO> GetByUser(UserTO user)
        {
            if (user.Role == UserRole.Assistant)
                throw new ArgumentException("Assistant can not subscribe to sessions");

            return GetAll().Where(x => (x.Attendees.Any(y => y.Id == user.Id))
            || (x.Teacher.Id == user.Id));
        }

        public IEnumerable<SessionTO> GetSessionsByDate(DateTime date)
            => GetAll().Where(x => x.SessionDays.Any(y => y.Date == date));
    }
}