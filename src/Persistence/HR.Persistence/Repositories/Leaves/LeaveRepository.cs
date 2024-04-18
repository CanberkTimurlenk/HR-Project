using HR.Application.Contracts.Repositories.Common;
using HR.Application.Contracts.Repositories.Leaves;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.Leaves;

public class LeaveRepository(HrDbContext context) : EfBaseRepository<Leave>(context), ILeaveRepository
{

}
