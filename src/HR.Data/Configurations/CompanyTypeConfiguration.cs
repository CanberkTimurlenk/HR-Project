using HR.Data.Configurations.Common;
using HR.Data.Entities.Concrete;
using HR.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations;

public class CompanyTypeConfiguration
    : BaseEntityConfiguration<CompanyType>
{
    public override void Configure(EntityTypeBuilder<CompanyType> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.TypeName).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

        builder.HasData(
            new CompanyType
            {
                Id = 1,
                TypeName = "Limited Company",
                Description = "",
                IsActive = true
            },
            new CompanyType
            {
                Id = 2,
                TypeName = "Public Company",
                Description = "",
                IsActive = true
            },
            new CompanyType
            {
                Id = 3,
                TypeName = "Private Company",
                Description = "",
                IsActive = true
            },
            new CompanyType
            {
                Id = 4,
                TypeName = "Holding Company",
                Description = "",
                IsActive = true
            },
            new CompanyType
            {
                Id = 5,
                TypeName = "Joint Venture",
                Description = "",
                IsActive = true
            }
        );
    }
}
