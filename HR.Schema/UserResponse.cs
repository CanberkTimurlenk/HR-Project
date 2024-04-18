using System.Data;

namespace HR.Schema;

public class UserResponse
{
    public int Id { get; set; }
    public string TurkishIdentificationNumber { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfEmployment { get; set; }
    public DateTime? DateOfDismissal { get; set; }
    public string Company { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public bool IsActive { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Salary { get; set; }
    public string PhotoFile { get; set; }
    public string Role { get; set; }
    public string? ResetPassword { get; set; }
    public ICollection<LeaveResponse> Leaves { get; set; }
    public ICollection<ExpenseResponse> Expenses { get; set; }
}

