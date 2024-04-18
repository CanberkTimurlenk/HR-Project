using HR.Base;
using HR.Domain.Enums;

namespace HR.Domain.Entities.Concrete;

public sealed class Advance : BaseEntity
{
    public int AdvanceTypeId { get; set; }
    public AdvanceType AdvanceType { get; set; }
    public DateTime RequestDate { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
    public DateTime? ResponseDate { get; set; }

    public decimal Amount { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public string Description { get; set; }

    public int CreatorEmployeeId { get; set; }
    public Employee CreatorEmployee { get; set; }

    public int ReviewerManagerId { get; set; }
    public Manager ReviewerManager { get; set; }
}