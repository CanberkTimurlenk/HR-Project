using HR.Application.Contracts.Repositories.Expenses;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.Expenses;

public class ExpenseRepository(HrDbContext context) : EfBaseRepository<Expense>(context), IExpenseRepository
{
}
