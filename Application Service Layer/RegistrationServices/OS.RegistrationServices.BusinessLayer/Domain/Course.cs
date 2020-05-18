using System;
using System.Collections.Generic;
using System.Text;
using OS.Common.Extensions;

namespace OS.RegistrationServices.BusinessLayer
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsValid()
        {
            Name.IsNullOrWhiteSpace("Course Name should not be empty nor whitespaces");

            return true;
        }

        public bool IsArchived { get; set; }
    }
}