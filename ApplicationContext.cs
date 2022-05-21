using Kursach.Models.User;
using System.Data.Entity;
namespace Kursach
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public ApplicationContext() : base("DefaultConnection")
        {

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
