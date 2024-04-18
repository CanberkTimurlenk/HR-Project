﻿using HR.Data.Entities.Abstract;
using HR.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations.Common;

public class ApplicationUserConfiguration//<ApplicationUser>
    : BaseEntityConfiguration<ApplicationUser>
//where TEntity : ApplicationUser
{
    public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        base.Configure(builder);

        builder.ToTable($"{nameof(ApplicationUser)}s")
                .HasDiscriminator<string>("UserType")
                .HasValue<Admin>("Admin")
                .HasValue<Employee>("Employee")
                .HasValue<Manager>("Manager");

        builder.Property(u => u.Firstname)
                .IsRequired()
                .HasMaxLength(50);

        builder.Property(u => u.Lastname)
                .IsRequired()
                .HasMaxLength(50);

        builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(70);

        builder.Property(u => u.Password)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(u => u.DateOfBirth)
                .IsRequired()
                .HasColumnType("Date");

        builder.Property(u => u.CreatedDate)
                .HasDefaultValueSql("CURRENT_DATE");
    }
}
