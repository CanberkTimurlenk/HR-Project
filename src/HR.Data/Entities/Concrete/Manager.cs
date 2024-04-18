using HR.Base;
using HR.Data.Entities.Abstract;

namespace HR.Data.Entities.Concrete;
public class Manager : ServiceUser
{
    public ICollection<Expense> ReviewedExpenses { get; set; }
    public ICollection<Leave> ReviewedLeaves { get; set; }
    public ICollection<Advance> ReviewedAdvances { get; set; }
}