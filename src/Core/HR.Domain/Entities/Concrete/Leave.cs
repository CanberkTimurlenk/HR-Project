using HR.Base;
using HR.Domain.Enums;

namespace HR.Domain.Entities.Concrete;
public class Leave : BaseEntity
{
    public int LeaveTypeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RequestDate { get; set; }
    public int NumberOfDays { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; }
    public DateTime? ResponseDate { get; set; }

    public int CreatorEmployeeId { get; set; }
    public Employee CreatorEmployee { get; set; }

    public Manager ReviewerManager { get; set; }
    public int ReviewerManagerId { get; set; }
}