using LibraryProject.DAL.ORM.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.DAL.ORM.Context
{
   public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=302--10;Database=CoreLibraryProject;UID=sa;PWD=1234;");
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
