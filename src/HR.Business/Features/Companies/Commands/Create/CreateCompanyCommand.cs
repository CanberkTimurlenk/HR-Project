using HR.Base.Response;
using MediatR;

namespace HR.Business.Companies.Commands.Create;
public record CreateCompanyCommand(string FileName, CreateCompanyCommandRequest Model) : IRequest<ApiResponse<int>>;

public record CreateCompanyCommandRequest
{
    public string Name { get; set; }
    public int Type { get; set; }
    public string MersisNumber { get; set; }
    public string TaxNumber { get; set; }
    public string TaxOffice { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public int EmployeeCount { get; set; }
    public int EstablishmentYear { get; set; }
    public DateTime ContractStartDate { get; set; }
    public DateTime ContractEndDate { get; set; }
}