using HR.Base;

namespace HR.Domain.Entities.Concrete;

public sealed class AdvanceType : BaseEntity
{
    public string TypeName { get; set; }
    public string Description { get; set; }

    public ICollection<Advance> Advances { get; set; }
}
