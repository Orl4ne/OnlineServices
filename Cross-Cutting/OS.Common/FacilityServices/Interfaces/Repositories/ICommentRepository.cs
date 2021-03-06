﻿using OS.Common.DataAccessHelpers;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OS.Common.FacilityServices.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<CommentTO, int>
    {
        List<CommentTO> GetCommentsByIncident(int incidentId);
    }
}
