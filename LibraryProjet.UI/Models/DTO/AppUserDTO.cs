﻿using LibraryProject.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProjet.UI.Models.DTO
{
    public class AppUserDTO
    {
        public int ID  { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
