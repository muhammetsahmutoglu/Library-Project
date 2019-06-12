using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.DAL.ORM.Entity
{
   public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }       

        public string AuthorFullName { get; set; }
    }
}
