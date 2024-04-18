using HR.Application.Contracts.Repositories.Admins;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.Advances;

public class AdvanceRepository(HrDbContext context) : EfBaseRepository<Advance>(context), IAdvanceRepository
{
}
