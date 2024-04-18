using HR.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations.Common;


public abstract class ServiceUserConfiguration<TEntity>
    : ApplicationUserConfiguration<TEntity>
    where TEntity : ServiceUser
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
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