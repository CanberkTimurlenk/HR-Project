using HR.Domain.Entities.Concrete;
using HR.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.Configurations.Role;

public class ManagerConfiguration
    : ServiceUserConfiguration<Manager>
{
    public override void Configure(EntityTypeBuilder<Manager> builder)
    {
        base.Configure(builder);

        builder.HasData(
            new Manager
            {
                Id = 1,
                TurkishIdentificationNumber = "12345678901",
                Firstname = "John",
                Middlename = "-",
                Lastname = "Doe",
                Email = "manager@mail.com",
                Password = "ba394499b56b89fe5bda1338fcca6a04",
                DateOfBirth = new DateTime(1980, 1, 1),
                CompanyId = 1,
                Department = "IT",
                IsActive = true,
                PhoneNumber = "1234567890",
                PhotoFile = "",
                LastLogin = DateTimeOffset.Now,
                CreatedDate = DateTimeOffset.Now,
            });
    }
}
