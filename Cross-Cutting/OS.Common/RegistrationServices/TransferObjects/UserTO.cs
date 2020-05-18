using OS.Common.DataAccessHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OS.Common.RegistrationServices.TransferObjects
{
    public class UserTO : IEntity<int>, IEquatable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } // Non Null
        public string Company { get; set; }
        public string Email { get; set; } // Non Null
        public bool IsArchived { get; set; } // Non Null
        public UserRole Role { get; set; } // Non Null

        public bool Equals(int otherId)
            => Id == otherId;

        public override bool Equals(object obj)
            => Equals(Id);
    }
}