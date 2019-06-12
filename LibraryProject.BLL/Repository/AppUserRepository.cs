using LibraryProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProject.BLL.Repository
{
    public class AppUserRepository : BaseRepository<AppUser>
    {
        public bool CheckCredentials(string UserName, string Password)
        {
            return table.Any(x => x.UserName == UserName && x.Password == Password);
        }

        public AppUser FindByUserName(string UserName)
        {
            return table.FirstOrDefault(x => x.UserName == UserName);

        }
    }
}
