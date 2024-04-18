using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations;

public class AdvanceConfiguration : BaseEntityConfiguration<Advance>
{
    public override void Configure(EntityTypeBuilder<Advance> builder)
    {
        base.Configure(builder);

        builder.Property(a => a.RequestDate)
            .IsRequired();

        builder.Property(a => a.ApprovalStatus)
            .IsRequired();

        builder.Property(a => a.ResponseDate);

        builder.Property(a => a.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(a => a.CurrencyType)
            .IsRequired();

        builder.Property(a => a.Description)
            .HasMaxLength(255);

        builder.HasOne(a => a.CreatorEmployee)
            .WithMany(e => e.Advances)
            .HasForeignKey(a => a.CreatorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.ReviewerManager)
            .WithMany(m => m.ReviewedAdvances)
            .HasForeignKey(a => a.ReviewerManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}