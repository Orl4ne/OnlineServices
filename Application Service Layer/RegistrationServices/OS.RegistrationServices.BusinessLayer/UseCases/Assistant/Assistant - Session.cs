using System;
using System.Collections.Generic;
using System.Text;
using OS.Common.Extensions;
using OS.RegistrationServices.BusinessLayer.Extensions;
using OS.Common.RegistrationServices.Interfaces;
using System.Linq;
using OS.Common.RegistrationServices;
using OS.Common.RegistrationServices.TransferObjects;
using OS.Common.Exceptions;

namespace OS.RegistrationServices.BusinessLayer.UseCase.Assistant
{
    public partial class RSAssistantRole : IRSAssistantRole
    {
        public bool AddSession(SessionTO sessionTO)
        {
            if (sessionTO is null)
                throw new ArgumentNullException(nameof(sessionTO));

            if (sessionTO.Id != 0)
                throw new Exception("Existing Session");

            try
            {
                iRSUnitOfWork.SessionRepository.Add(sessionTO.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateSession(SessionTO sessionTO)
        {
            if (sessionTO is null)
                throw new ArgumentNullException((nameof(sessionTO)));

            if (sessionTO.Id == 0)
                throw new Exception("User does not exist");

            try
            {
                iRSUnitOfWork.SessionRepository.Update(sessionTO.ToDomain().ToTransfertObject());
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveSession(SessionTO sessionTO)
        {
            if (sessionTO is null)
                throw new ArgumentNullException(nameof(sessionTO));

            if (sessionTO.Id == 0)
                throw new Exception("User does not exist");

            try
            {
                iRSUnitOfWork.SessionRepository.Remove(sessionTO.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<SessionTO> GetSessions()
        {
            return iRSUnitOfWork.SessionRepository.GetAll().Select(x => x.ToDomain().ToTransfertObject()).ToList();
        }

        public SessionTO GetSessionById(int id)
        {
            return iRSUnitOfWork.SessionRepository.GetById(id);
        }

        public List<SessionDayTO> GetSessionsDay()
        {
            return GetSessions().SelectMany(x=>x.SessionDays).ToList();
        }
    }
}
