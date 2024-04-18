using HR.Base;

namespace HR.Data.Entities.Concrete;
public class LeaveType : BaseEntity
{
    public string TypeName { get; set; }
    public string Description { get; set; }

    public ICollection<Leave> Leaves { get; set; }
}