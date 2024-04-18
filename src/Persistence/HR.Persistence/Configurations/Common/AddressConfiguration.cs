using HR.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations.Common;
public class AddressConfiguration
    : BaseEntityConfiguration<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);

        builder.ToTable($"{nameof(Address)}es")
                .HasDiscriminator<int>("AddressTypes")
                .HasValue<ServiceUserAddress>(1)
                .HasValue<CompanyAddress>(2);

        builder.Property(a => a.Street)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.City)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.State)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Country)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.PostalCode)
            .HasMaxLength(5)
            .IsFixedLength()
            .IsRequired();

    }
}
