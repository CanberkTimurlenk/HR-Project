using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations;

public class ExpenseConfiguration : BaseEntityConfiguration<Expense>
{
    public override void Configure(EntityTypeBuilder<Expense> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Amount)
            .HasPrecision(18, 2);

        builder.Property(e => e.CurrencyType)
            .IsRequired();

        builder.Property(e => e.ApprovalStatus)
            .IsRequired();

        builder.Property(e => e.RequestDate)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(e => e.CreatorEmployee)
               .WithMany(ce => ce.Expenses)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ReviewerManager)
               .WithMany(rm => rm.ReviewedExpenses)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ExpenseType)
            .WithMany(et => et.Expenses)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
