﻿using OS.Common.DataAccessHelpers;
using System;

namespace OS.Common.FacilityServices.TransfertObjects
{
    public class CommentTO : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IncidentTO Incident { get; set; }
        public string Message { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}
