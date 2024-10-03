using Microsoft.EntityFrameworkCore;
using POC.Domain;

namespace POC.DataTables.UI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.Person> Persons { get; set; }
        
        public DbSet<MainSettings> MainSettings { get; set; }
        
        // public DbSet<Settings<ModulePrimarySettings>> ModulePrimarySettings { get; set; }
        //
        // public DbSet<Settings<ModuleSecondarySettings>> ModuleSecondarySettings { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ModulePrimarySettings>();
            modelBuilder.Entity<ModuleSecondarySettings>();

            modelBuilder.Entity<MainSettings>()
                .HasOne(e => e.ModulePrimarySettings)
                .WithOne()
                .HasForeignKey<ModulePrimarySettings>(e => e.Id);
            
            modelBuilder.Entity<MainSettings>()
                .HasOne(e => e.ModuleSecondarySettings)
                .WithOne()
                .HasForeignKey<ModuleSecondarySettings>(e => e.Id);

            modelBuilder.Entity<MainSettings>()
                .OwnsOne<ApplicationSettingsData>(x => x.Value, builder => builder.ToJson());
            
            modelBuilder.Entity<ModulePrimarySettings>()
                .OwnsOne<ModulePrimarySettingsData>(x => x.Value, builder => builder.ToJson());
            
            modelBuilder.Entity<ModuleSecondarySettings>()
                .OwnsOne<ModuleSecondarySettingsData>(x => x.Value, builder => builder.ToJson());


        }
    }
}

