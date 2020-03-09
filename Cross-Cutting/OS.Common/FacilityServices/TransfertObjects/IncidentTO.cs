using OS.Common.DataAccessHelpers;
using OS.Common.FacilityServices.Enumerations;

using System;

namespace OS.Common.FacilityServices.TransfertObjects
{
    public class IncidentTO : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public RoomTO Room { get; set; }
        public IssueTO Issue { get; set; }
        //public List<CommentTO> AssistantComments { get; set; } = new List<CommentTO>();
        public string Description { get; set; }
        public DateTime SubmitDate { get; set; }
        public IncidentStatus Status { get; set; }
    }

}
