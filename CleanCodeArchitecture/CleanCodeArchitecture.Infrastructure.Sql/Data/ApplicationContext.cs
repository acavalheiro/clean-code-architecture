using CleanCodeArchitecture.Domain.Entities;
using CleanCodeArchitecture.Infrastructure.Sql.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeArchitecture.Infrastructure.Sql.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DbSet<Company> Companies { get; set; }

    //public DbSet<MainSettings> MainSettings { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>().ToTable("Persons");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyEntityType).Assembly);

    }

}