using Kursach.Models.User;
using Microsoft.EntityFrameworkCore;
namespace Kursach
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:kursachdbserver.database.windows.net,1433;Initial Catalog=Kursach_db;Persist Security Info=False;User ID=sqladmin;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
