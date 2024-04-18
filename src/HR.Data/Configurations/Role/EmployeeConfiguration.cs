using HR.Data.Configurations.Common;
using HR.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations.Role;


public class EmployeeConfiguration
    : ServiceUserConfiguration<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Salary).HasPrecision(18, 2);
        builder.Property(e => e.DateOfEmployment).HasColumnType("Date");
        builder.Property(e => e.DateOfDismissal).HasColumnType("Date");

        builder.HasData(
            new Employee
            {
                Id = 2,
                TurkishIdentificationNumber = "12345678902",
                Firstname = "Jane",
                Middlename = "-",
                Lastname = "Doe",
                Email = "employee@mail.com",
                Password = "ba394499b56b89fe5bda1338fcca6a04",
                DateOfBirth = new DateTime(1980, 1, 1),
                DateOfEmployment = new DateTime(2010, 1, 1),
                DateOfDismissal = null,
                CompanyId = 1,
                Department = "IT",
                IsActive = true,
                PhoneNumber = "1234567890",
                Salary = 10000,
                LastLogin = DateTimeOffset.Now,
                CreatedDate = DateTimeOffset.Now,
                PhotoFile = "https://images.unsplash.com/photo-1530785602389-07594beb8b73?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            }
        );
    }
}