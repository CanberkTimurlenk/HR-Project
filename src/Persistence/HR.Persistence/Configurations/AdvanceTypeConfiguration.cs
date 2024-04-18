using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations;
public class AdvanceTypeConfiguration
    : BaseEntityConfiguration<AdvanceType>
{
    public override void Configure(EntityTypeBuilder<AdvanceType> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.TypeName).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

        builder.HasData(
            new AdvanceType
            {
                Id = 1,
                TypeName = "Salary",
                Description = "Salary",
                IsActive = true
            },
            new AdvanceType
            {
                Id = 2,
                TypeName = "Business",
                Description = "Business",
                IsActive = true
            },
            new AdvanceType
            {
                Id = 3,
                TypeName = "Other",
                Description = "Other",
                IsActive = true
            }
        );
    }
}
