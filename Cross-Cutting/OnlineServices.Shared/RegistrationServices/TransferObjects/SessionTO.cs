﻿using OnlineServices.Common.DataAccessHelpers;

using System.Collections.Generic;

namespace OnlineServices.Common.RegistrationServices.TransferObject
{
    public class SessionTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public UserTO TeacherName { get; set; }
        public CourseTO Course { get; set; }
        public ICollection<UserTO> Attendees { get; set; }
    }
}