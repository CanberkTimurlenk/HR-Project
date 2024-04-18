using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations;

public class ServiceUserAddressConfiguration
    : BaseEntityConfiguration<ServiceUserAddress>
{
    public override void Configure(EntityTypeBuilder<ServiceUserAddress> builder)
    {
        base.Configure(builder);

        builder.HasData(
            new ServiceUserAddress
            {
                Id = 1,
                Street = "123 Main Street",
                City = "Sample City",
                State = "Sample State",
                PostalCode = "12345",
                Country = "Sample Country",
                ServiceUserId = 1
            },
            new ServiceUserAddress
            {
                Id = 2,
                Street = "456 Oak Avenue",
                City = "Another City",
                State = "Another State",
                PostalCode = "54321",
                Country = "Another Country",
                ServiceUserId = 2
            });
    }
}
