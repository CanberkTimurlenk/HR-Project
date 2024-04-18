using HR.Base;

namespace HR.Domain.Entities.Concrete;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string MersisNumber { get; set; }
    public string TaxNumber { get; set; }
    public string TaxOffice { get; set; }
    public string LogoFile { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int EmployeeCount { get; set; }
    public int EstablishmentYear { get; set; }
    public DateTime ContractStartDate { get; set; }
    public DateTime ContractEndDate { get; set; }

    public int CompanyTypeId { get; set; }
    public CompanyType CompanyType { get; set; }

    public int AddressId { get; set; }
    public CompanyAddress Address { get; set; }
}
