using HR.Application.Contracts.Repositories.ServiceUserAdresses;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.ServiceUserAddresses;

public class ServiceUserAddressRepository(HrDbContext context) : EfBaseRepository<ServiceUserAddress>(context), IServiceUserAddressRepository
{

}
