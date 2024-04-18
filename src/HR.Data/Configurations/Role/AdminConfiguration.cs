using HR.Data.Configurations.Common;
using HR.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations.Role;

/*
public class AdminConfiguration
    : ApplicationUserConfiguration<Admin>

{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        base.Configure(builder);

        builder.HasData(new Admin
        {
            Id = 3,
            Firstname = "Site",
            Middlename = "-",
            Lastname = "Yoneticisi",
            Email = "yonetici@bilgeadam.com",
            Password = "ba394499b56b89fe5bda1338fcca6a04",
            DateOfBirth = new DateTime(1980, 1, 1),
            IsActive = true,
            LastLogin = DateTimeOffset.Now,
            CreatedDate = DateTimeOffset.Now,
            PhotoFile = "https://images.unsplash.com/photo-1530785602389-07594beb8b73?q=80&w=1587&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        });
    }
}
*/