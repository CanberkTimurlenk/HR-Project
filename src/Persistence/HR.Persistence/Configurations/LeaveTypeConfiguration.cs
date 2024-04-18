using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations;

public class LeaveTypeConfiguration :
    BaseEntityConfiguration<LeaveType>
{
    public override void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.TypeName).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

        builder.HasData(
            new LeaveType
            {
                Id = 1,
                TypeName = "Annual Leave",
                Description = "annual",
                IsActive = true
            },
            new LeaveType
            {
                Id = 2,
                TypeName = "Maternity Leave",
                Description = "",
                IsActive = true
            },
            new LeaveType
            {
                Id = 3,
                TypeName = "Paternity Leave",
                Description = "",
                IsActive = true
            },
            new LeaveType
            {
                Id = 4,
                TypeName = "Marriage Leave",
                Description = "",
                IsActive = true
            },
            new LeaveType
            {
                Id = 5,
                TypeName = "Bereavement Leave",
                Description = "",
                IsActive = true
            });
    }
}
