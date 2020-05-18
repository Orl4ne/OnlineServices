﻿using OS.Common.Exceptions;
using OS.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class FSAttendeeRole
    {
        public List<IncidentTO> GetUserIncidents(int userId)
        {
            if (userId <= 0)
            {
                throw new LoggedException($"Invalid user ID (ID={userId})");
            }

            // Todo check unique constraints, check if room + componenttype exists, etc.
            var incidents = unitOfWork.IncidentRepository.GetIncidentsByUserId(userId);
            return incidents;
        }
    }
}
