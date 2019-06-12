using LibraryProject.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProjet.UI.Models.VM
{
    public class BookVM
    {
        public BookVM()
        {
            Books = new List<Book>();
            Authors = new List<AppUser>();
            user = new AppUser();
        }
        public List<Book> Books { get; set; }
        public List<AppUser> Authors{ get; set; }
        public AppUser user { get; set; }
    }
}
