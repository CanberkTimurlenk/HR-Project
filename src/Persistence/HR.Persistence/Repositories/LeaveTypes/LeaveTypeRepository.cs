using HR.Application.Contracts.Repositories.LeaveTypes;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;
namespace HR.Persistence.Repositories.LeaveTypes;

public class LeaveTsypeRepository(HrDbContext context) : EfBaseRepository<LeaveType>(context), ILeaveTypeRepository
{
}
