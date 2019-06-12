using LibraryProject.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.DAL.ORM.Entity
{
   public class AppUser:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        
    }
}
