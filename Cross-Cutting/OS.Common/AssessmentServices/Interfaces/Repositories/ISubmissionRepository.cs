﻿using OS.Common.DataAccessHelpers;
using OS.Common.AssessementServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Common.AssessementServices.Interfaces.Repositories
{
    public interface ISubmissionRepository : IRepository<SubmissionTO, int>
    {
        //SubmissionTO GetById(int Id);
        //bool Remove(SubmissionTO entity);
        //bool Remove(int Id);
        //SubmissionTO Update(SubmissionTO Entity);
        bool IsAlreadySubmitted(int attendeeID, int sessionId, int formId);
    }
}
