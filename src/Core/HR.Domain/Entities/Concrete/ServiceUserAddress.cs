using HR.Domain.Entities.Abstract;

namespace HR.Domain.Entities.Concrete;

public class ServiceUserAddress
    : Address
{
    public int ServiceUserId { get; set; }
    public ServiceUser ServiceUser { get; set; }
}
