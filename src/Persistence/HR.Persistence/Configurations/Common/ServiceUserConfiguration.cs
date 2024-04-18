using HR.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations.Common;


public abstract class ServiceUserConfiguration<TEntity>
    : ApplicationUserConfiguration<TEntity>
    where TEntity : ServiceUser
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(su => su.TurkishIdentificationNumber)
            .IsRequired()
            .HasMaxLength(11)
            .IsFixedLength();

        builder.Property(su => su.Department)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(su => su.PhoneNumber)
            .IsRequired();
    }
}