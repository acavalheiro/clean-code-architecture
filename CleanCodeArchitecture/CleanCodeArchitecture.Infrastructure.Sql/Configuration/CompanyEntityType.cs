using CleanCodeArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCodeArchitecture.Infrastructure.Sql.Configuration;

public class CompanyEntityType : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(k => k.Id);
        
        builder.HasOne<MainSettings>()
            .WithOne()
            .HasForeignKey<MainSettings>(e => e.Id);
    }
}

public class ModuleSettings : IEntityTypeConfiguration<ModulePrimarySettings>
{
    public void Configure(EntityTypeBuilder<ModulePrimarySettings> builder)
    {
        builder.OwnsOne<ModulePrimarySettingsData>(x => x.Value, builder => builder.ToJson());
    }

    }

public class ModuleSecondarySettingsEntityType :IEntityTypeConfiguration<ModuleSecondarySettings>
{
    public void Configure(EntityTypeBuilder<ModuleSecondarySettings> builder)
    {
        builder.OwnsOne<ModuleSecondarySettingsData>(x => x.Value, builder => builder.ToJson());
    }
}