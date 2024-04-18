using HR.Base;

namespace HR.Domain.Entities.Abstract;
public abstract class ApplicationUser : BaseEntity
{
    public string Firstname { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhotoFile { get; set; }
    public string? ResetPassword { get; set; }
    public DateTimeOffset LastLogin { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}