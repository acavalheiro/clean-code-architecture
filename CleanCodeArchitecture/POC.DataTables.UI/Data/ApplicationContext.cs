using Microsoft.EntityFrameworkCore;

namespace POC.DataTables.UI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.Person> Persons { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

    }
}
