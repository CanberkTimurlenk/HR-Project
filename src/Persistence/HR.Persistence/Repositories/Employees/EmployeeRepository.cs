using HR.Application.Contracts.Repositories.Common;
using HR.Application.Contracts.Repositories.Employees;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.Employees;

public class EmployeeRepository(HrDbContext context) : EfBaseRepository<Employee>(context), IEmployeeRepository
{

}
