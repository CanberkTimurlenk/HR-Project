using HR.Application.Contracts.Repositories.Admins;
using HR.Application.Contracts.Repositories.Advances;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;
using HR.Schema.Response;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories.Advances;

public class AdvanceRepository(HrDbContext context) : EfBaseRepository<Advance>(context), IAdvanceRepository
{   
}
