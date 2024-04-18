using HR.Application.Contracts.Repositories.Admins;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.Admins;

public class AdminRepository(HrDbContext context) : EfBaseRepository<Admin>(context), IAdminRepository
{
}
