using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_7_MVC.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
                
        }

        public DbSet<Person> Person { get; set; }
    }
}
