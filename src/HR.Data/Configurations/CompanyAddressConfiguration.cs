using HR.Data.Configurations.Common;
using HR.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations;

public class CompanyAddressConfiguration
    : BaseEntityConfiguration<CompanyAddress>
{
    public override void Configure(EntityTypeBuilder<CompanyAddress> builder)
    {
        base.Configure(builder);

        builder.HasData(new CompanyAddress()
        {
            Id = 3,
            Street = "789 Pine Lane",
            City = "Third City",
            State = "Third State",
            PostalCode = "67890",
            Country = "Third Country",
            CompanyId = 1,
        });
    }

}
