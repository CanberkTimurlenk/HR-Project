using HR.Base;
using HR.Data.Enums;

namespace HR.Data.Entities.Concrete;

public class Expense : BaseEntity
{
    public ExpenseType ExpenseType { get; set; }
    public decimal Amount { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public string FileUrl { get; set; } // Azure Blob Storage ??? 

    public int CreatorEmployeeId { get; set; }
    public Employee CreatorEmployee { get; set; }

    public int ReviewerManagerId { get; set; }
    public Manager ReviewerManager { get; set; }
}