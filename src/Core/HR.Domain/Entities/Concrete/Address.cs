using HR.Base;

namespace HR.Domain.Entities.Concrete;
public abstract class Address
    : BaseEntity

{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}