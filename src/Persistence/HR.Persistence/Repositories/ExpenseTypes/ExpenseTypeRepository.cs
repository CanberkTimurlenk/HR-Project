using HR.Application.Contracts.Repositories.ExpenseTypes;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.ExpenseTypes;

public class ExpenseTypeRepository(HrDbContext context) : EfBaseRepository<ExpenseType>(context), IExpenseTypeRepository
{

}
