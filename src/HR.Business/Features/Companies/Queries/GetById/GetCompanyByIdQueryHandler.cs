using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using HR.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Features.Companies.Queries.GetById;

public class GetCompanyByIdQueryHandler(HrDbContext dbContext, IMapper mapper) : IRequestHandler<GetCompanyByIdQuery, ApiResponse<CompanyResponse>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<CompanyResponse>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await dbContext.Companies.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (company == null)
            return new ApiResponse<CompanyResponse>("Not Found!");

        if (company.ContractEndDate < DateTime.Now)
            company.IsActive = false;

        var response = mapper.Map<CompanyResponse>(company);
        return new ApiResponse<CompanyResponse>(data: response);
    }
}
