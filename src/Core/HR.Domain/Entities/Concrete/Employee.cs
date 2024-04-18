using HR.Domain.Entities.Abstract;

namespace HR.Domain.Entities.Concrete;
public class Employee : ServiceUser
{
    public DateTime DateOfEmployment { get; set; }
    public DateTime? DateOfDismissal { get; set; }
    public decimal Salary { get; set; }

    public ICollection<Leave> Leaves { get; set; }
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<Advance> Advances { get; set; }
}