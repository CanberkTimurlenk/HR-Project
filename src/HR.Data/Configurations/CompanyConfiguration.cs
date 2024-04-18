using HR.Data.Configurations.Common;
using HR.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Configurations;

public class CompanyConfiguration
    : BaseEntityConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.MersisNumber)
            .IsRequired()
            .HasMaxLength(16)
            .IsFixedLength();

        builder.Property(c => c.TaxNumber)
            .IsRequired()
            .HasMaxLength(10)
            .IsFixedLength();

        builder.Property(c => c.TaxOffice)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.PhoneNumber)
            .IsRequired();

        builder.Property(c => c.AddressId)
            .IsRequired();

        builder.Property(c => c.Email)
            .IsRequired();

        builder.Property(c => c.EstablishmentYear)
            .IsRequired();

        builder.Property(c => c.ContractStartDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(c => c.ContractEndDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(c => c.CompanyTypeId)
            .IsRequired();

        builder.HasOne(c => c.Address)
            .WithOne(a => a.Company)
            .HasForeignKey<CompanyAddress>(c => c.CompanyId);

        builder.HasData(
            new Company
            {
                Id = 1,
                Name = "Sample Company",
                MersisNumber = "1234567890",
                TaxNumber = "0987654321",
                TaxOffice = "Sample Tax Office",
                LogoFile = "company_logo.png",
                PhoneNumber = "123-456-7890",
                Email = "sample@example.com",
                EmployeeCount = 100,
                EstablishmentYear = 2000,
                ContractStartDate = DateTime.Now.AddDays(-30),
                ContractEndDate = DateTime.Now.AddMonths(6),
                CompanyTypeId = 1,
                AddressId = 3
            });
    }
}
