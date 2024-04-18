namespace HR.Domain.Entities.Concrete;

public class CompanyAddress
    : Address
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}
