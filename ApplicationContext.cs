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
}
