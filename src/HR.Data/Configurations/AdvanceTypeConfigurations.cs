using HR.Data.Configurations.Common;
using HR.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations;
public class AdvanceTypeConfigurations
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
