using HR.Application.Contracts.Repositories.CompanyAddresses;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.CompanyAddresses;

public class CompanyAddressRepository(HrDbContext context) : EfBaseRepository<CompanyAddress>(context), ICompanyAddressRepository
{

}
