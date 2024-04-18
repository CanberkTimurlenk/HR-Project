using HR.Application.Contracts.Repositories.Admins;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.Companies;

public class CompanyRepository(HrDbContext context) : EfBaseRepository<Company>(context), ICompanyRepository
{

}
