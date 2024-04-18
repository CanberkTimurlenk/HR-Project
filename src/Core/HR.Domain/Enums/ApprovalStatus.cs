namespace HR.Domain.Enums;
public enum ApprovalStatus
{
    Pending, // askıda, henüz yönetici bakmadı
    Approved, // yönetici onayladı
    Rejected, // yönetici reddetti  
    Canceled // çalışanın kendisi iptal etti
}
