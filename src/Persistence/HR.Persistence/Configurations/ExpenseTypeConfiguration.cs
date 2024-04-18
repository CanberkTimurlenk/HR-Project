using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations;

public abstract class ExpenseTypeConfiguration
    : BaseEntityConfiguration<ExpenseType>

{
    public override void Configure(EntityTypeBuilder<ExpenseType> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.TypeName).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500).IsRequired();

        builder.HasData(
            new ExpenseType
            {
                Id = 1,
                TypeName = "Office Supplies",
                Description = "Office Supplies",
                IsActive = true
            },
            new ExpenseType
            {
                Id = 2,
                TypeName = "Travel Expenses",
                Description = "Travel Expenses",
                IsActive = true
            },
            new ExpenseType
            {
                Id = 3,
                TypeName = "Advertising",
                Description = "Advertising",
                IsActive = true
            }
        );
    }
}