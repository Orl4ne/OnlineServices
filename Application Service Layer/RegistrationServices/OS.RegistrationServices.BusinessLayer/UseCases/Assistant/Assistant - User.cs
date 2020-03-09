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
        public bool AddUser(UserTO userTO)
        {
            if (userTO is null)
                throw new LoggedException(new ArgumentNullException(nameof(userTO)));

            if (userTO.Id != 0)
                throw new Exception("Existing user");

            userTO.Name.IsNullOrWhiteSpace("Missing User Name.");

            try
            {
                iRSUnitOfWork.UserRepository.Add(userTO.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateUser(UserTO userTO)
        {
            if (userTO is null)
                throw new ArgumentNullException((nameof(userTO)));

            if (userTO.Id == 0)
                throw new Exception("User does not exist");

            userTO.Name.IsNullOrWhiteSpace("Missing User Name");

            try
            {
                iRSUnitOfWork.UserRepository.Update(userTO.ToDomain().ToTransfertObject());
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveUser(UserTO userTO)
        {
            if (userTO is null)
                throw new ArgumentNullException(nameof(userTO));

            if (userTO.Id == 0)
                throw new Exception("User does not exist");

            try
            {
                iRSUnitOfWork.UserRepository.Remove(userTO.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<UserTO> GetUsers()
        {
            return iRSUnitOfWork.UserRepository.GetAll().Select(x => x.ToDomain().ToTransfertObject()).ToList();
        }

        public UserTO GetUserById(int id)
        {
            return iRSUnitOfWork.UserRepository.GetById(id);
        }

        //TODO To be checked
        public List<UserTO> GetUsersBySession(int sessionId)
        {
            throw new NotImplementedException();
        }

        //TODO To be checked
        public bool IsUserInSession(int userId, int sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
