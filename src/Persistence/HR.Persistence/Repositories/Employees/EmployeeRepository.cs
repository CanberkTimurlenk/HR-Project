using HR.Application.Contracts.Repositories.Common;
using HR.Application.Contracts.Repositories.Employees;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Repositories.Employees;

public class EmployeeRepository(HrDbContext context) : EfBaseRepository<Employee>(context), IEmployeeRepository
{
    public async Task<IEnumerable<Advance>> GetAdvancesByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken)

        => await context.Employees.Where(e => e.Id.Equals(employeeId))
                    .SelectMany(e => e.Advances).ToListAsync(cancellationToken);



    public async Task<decimal> GetSalaryByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken)

        => await context.Employees.Where(e => e.Id.Equals(employeeId)).Select(e => e.Salary).FirstOrDefaultAsync(cancellationToken);


}
