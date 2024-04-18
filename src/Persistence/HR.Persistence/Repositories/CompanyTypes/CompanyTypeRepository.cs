using HR.Application.Contracts.Repositories.CompanyTypes;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.CompanyTypes;

public class CompanyTypeRepository(HrDbContext context) : EfBaseRepository<CompanyType>(context), ICompanyTypeRepository
{
}