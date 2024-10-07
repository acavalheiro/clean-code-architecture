using System.Data.Entity;
using System.Data.Entity.SqlServer;
using POC.Domain;

namespace POC.NetFramework.WebApi.Data
{

    [DbConfigurationType(typeof(MicrosoftSqlDbConfiguration))]
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionSting) : base(connectionSting)
        {
            
        }
        public DbSet<MainSettings> MainSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MainSettings>().HasKey(x => x.Id);
            //modelBuilder.Entity<MainSettings>().Ignore(x => x.Value);
            modelBuilder.Entity<MainSettings>().Ignore(x => x.ValueData);

            modelBuilder.Entity<MainSettings>().Property(x => x.ValueString).HasColumnName("Value");

            modelBuilder.Entity<ModulePrimarySettings>().HasKey(x => x.Id);
            //modelBuilder.Entity<ModulePrimarySettings>().Ignore(x => x.Value);
            modelBuilder.Entity<ModulePrimarySettings>().Ignore(x => x.ValueData);
            modelBuilder.Entity<ModulePrimarySettings>().Property(x => x.ValueString).HasColumnName("Value");


            modelBuilder.Entity<MainSettings>()
                .HasRequired(t => t.ModulePrimarySettings)
                .WithRequiredPrincipal();

            //modelBuilder.Entity<ModuleSecondarySettings>();
            modelBuilder.Entity<ModuleSecondarySettings>().HasKey(x => x.Id);
            //modelBuilder.Entity<ModuleSecondarySettings>().Ignore(x => x.Value);
            modelBuilder.Entity<ModuleSecondarySettings>().Ignore(x => x.ValueData);
            modelBuilder.Entity<ModuleSecondarySettings>().Property(x => x.ValueString).HasColumnName("Value");

            modelBuilder.Entity<MainSettings>()
                .HasRequired(t => t.ModuleSecondarySettings)
                .WithRequiredPrincipal();
        }
    }
}