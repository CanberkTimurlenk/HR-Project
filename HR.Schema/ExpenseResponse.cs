namespace HR.Schema;

public class ExpenseResponse
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public int ExpenseType { get; set; }
    public decimal Amount { get; set; }
    public int CurrencyType { get; set; }
    public int ApprovalStatus { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public string File { get; set; }
    public int UserId { get; set; }
}
