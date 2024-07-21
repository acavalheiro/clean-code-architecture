using CleanCodeArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeArchitecture.Infrastructure.Sql.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("Persons");
    }
}