using HR.Application.Contracts.Repositories.Managers;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.Managers;

public class ManagerRepository(HrDbContext context) : EfBaseRepository<Manager>(context), IManagerRepository
{
}
