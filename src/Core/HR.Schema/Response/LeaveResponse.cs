namespace HR.Schema.Response;

public class LeaveResponse
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public int LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RequestDate { get; set; }
    public int NumberOfDays { get; set; }
    public int ApprovalStatus { get; set; }
    public DateTime? ResponseDate { get; set; }
    public int UserId { get; set; }
}
