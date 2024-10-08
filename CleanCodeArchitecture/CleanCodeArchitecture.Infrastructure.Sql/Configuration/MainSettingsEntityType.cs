using CleanCodeArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCodeArchitecture.Infrastructure.Sql.Configuration;

public class MainSettingsEntityType : IEntityTypeConfiguration<MainSettings>
{
    public void Configure(EntityTypeBuilder<MainSettings> builder)
    {
        builder
            .HasOne(e => e.ModulePrimarySettings)
            .WithOne()
            .HasForeignKey<ModulePrimarySettings>(e => e.Id);
            
        builder
            .HasOne(e => e.ModuleSecondarySettings)
            .WithOne()
            .HasForeignKey<ModuleSecondarySettings>(e => e.Id);

        builder
            .OwnsOne<ApplicationSettingsData>(x => x.Value, builder => builder.ToJson());

    }
}