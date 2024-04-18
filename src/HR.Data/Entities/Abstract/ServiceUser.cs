using HR.Data.Entities.Concrete;

namespace HR.Data.Entities.Abstract;

public abstract class ServiceUser : ApplicationUser
{
    public string? TurkishIdentificationNumber { get; set; }
    public string? Department { get; set; }
    public string? PhoneNumber { get; set; }

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public ICollection<ServiceUserAddress>? Addresses { get; set; }
}
