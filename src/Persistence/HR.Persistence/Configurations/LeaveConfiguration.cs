using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations;

public class LeaveConfiguration : BaseEntityConfiguration<Leave>
{
    public override void Configure(EntityTypeBuilder<Leave> builder)
    {
        base.Configure(builder);

        builder.Property(l => l.StartDate)
            .IsRequired();

        builder.Property(l => l.EndDate)
            .IsRequired();

        builder.Property(l => l.RequestDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.Property(l => l.NumberOfDays)
            .IsRequired();

        builder.Property(l => l.ApprovalStatus)
            .IsRequired();

        builder.HasOne(l => l.CreatorEmployee)
            .WithMany(ce => ce.Leaves)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.ReviewerManager)
            .WithMany(ce => ce.ReviewedLeaves)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.LeaveType)
            .WithMany(lt => lt.Leaves)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
