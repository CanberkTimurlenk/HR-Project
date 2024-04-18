using HR.Base;

namespace HR.Data.Entities.Concrete;

public class CompanyType : BaseEntity
{
    public string TypeName { get; set; }
    public string Description { get; set; }

    public ICollection<Company> Companies { get; set; }
}