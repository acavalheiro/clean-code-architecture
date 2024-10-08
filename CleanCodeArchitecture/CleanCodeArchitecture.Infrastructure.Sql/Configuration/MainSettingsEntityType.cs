using CleanCodeArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CleanCodeArchitecture.Infrastructure.Sql.Configuration;

public class MainSettingsEntityType : IEntityTypeConfiguration<MainSettings>
{
    public void Configure(EntityTypeBuilder<MainSettings> builder)
    {
        builder.ToTable("CompanySettings");

        builder
            .HasOne(e => e.ModulePrimarySettings)
            .WithOne()
            .HasForeignKey<ModulePrimarySettings>(e => e.Id);

        builder
            .HasOne(e => e.ModuleSecondarySettings)
            .WithOne()
            .HasForeignKey<ModuleSecondarySettings>(e => e.Id);

        builder
            .OwnsOne(x => x.Value, builder => builder.ToJson());

        //builder.HasData(new MainSettings() { Id = 1, Guid = Guid.Empty, Value = new ApplicationSettingsData(),ModulePrimarySettings  = null,ModuleSecondarySettings = null});

    }
}

public class ModuleSettings : IEntityTypeConfiguration<ModulePrimarySettings>
{
    public void Configure(EntityTypeBuilder<ModulePrimarySettings> builder)
    {
        builder.OwnsOne<ModulePrimarySettingsData>(x => x.Value, builder => builder.ToJson());
    }

}

public class ModuleSecondarySettingsEntityType : IEntityTypeConfiguration<ModuleSecondarySettings>
{
    public void Configure(EntityTypeBuilder<ModuleSecondarySettings> builder)
    {
        builder.OwnsOne<ModuleSecondarySettingsData>(x => x.Value, builder => builder.ToJson());
    }
}