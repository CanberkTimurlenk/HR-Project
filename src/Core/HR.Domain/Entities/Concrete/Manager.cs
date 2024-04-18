using HR.Base;
using HR.Domain.Entities.Abstract;

namespace HR.Domain.Entities.Concrete;
public class Manager : ServiceUser
{
    public ICollection<Expense> ReviewedExpenses { get; set; }
    public ICollection<Leave> ReviewedLeaves { get; set; }
    public ICollection<Advance> ReviewedAdvances { get; set; }
}