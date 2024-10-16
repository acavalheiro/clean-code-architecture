using CleanCodeArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanCodeArchitecture.Infrastructure.Sql.Configuration;

public class CompanyEntityType : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder
            .HasOne(x => x.MainSettings)
            .WithOne()
            .HasForeignKey<MainSettings>(e => e.Id);

       

        
    }
}

