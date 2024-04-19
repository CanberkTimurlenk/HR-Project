using HR.Application.Contracts.Repositories.Common;
using HR.Domain.Entities.Concrete;

namespace HR.Application.Contracts.Repositories.Employees;

public interface IEmployeeRepository : IRepository<Employee>
{
    public Task<decimal> GetSalaryByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken);

    public Task<IEnumerable<Advance>> GetAdvancesByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken);


}
