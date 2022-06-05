using Kursach.Models.User;
using Microsoft.EntityFrameworkCore;
namespace Kursach
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }


    }

    public static class DBExtention
    {
        public static void Clear(this DbSet<User> dbSet)
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
