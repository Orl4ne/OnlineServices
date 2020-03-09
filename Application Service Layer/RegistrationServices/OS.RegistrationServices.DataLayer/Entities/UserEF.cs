using OS.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OS.Common.RegistrationServices;

namespace OS.RegistrationServices.DataLayer.Entities
{
    [Table("User")]
    public class UserEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public bool IsArchived { get; set; }
        public List<UserSessionEF> UserSessions { get; set; }
    }
}