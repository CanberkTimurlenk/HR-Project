using HR.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations.Common;

public abstract class BaseEntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(b => b.IsActive)
            .HasDefaultValue(true);
    }
}
