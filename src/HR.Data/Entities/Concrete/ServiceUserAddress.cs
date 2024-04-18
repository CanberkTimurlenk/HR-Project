using HR.Data.Entities.Abstract;

namespace HR.Data.Entities.Concrete;

public class ServiceUserAddress
    : Address
{
    public int ServiceUserId { get; set; }
    public ServiceUser ServiceUser { get; set; }
}
