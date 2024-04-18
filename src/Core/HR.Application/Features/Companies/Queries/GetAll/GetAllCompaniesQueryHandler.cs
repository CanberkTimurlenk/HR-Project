using AutoMapper;
using HR.Data.Contexts;
using HR.Domain.Entities.Concrete;
using HR.Schema.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HR.Application.Features.Companies.Queries.GetAll;

public class GetAllCompaniesQueryHandler(HrDbContext dbContext, IMapper mapper) : IRequestHandler<GetAllCompaniesQuery, ApiResponse<IEnumerable<CompanyResponse>>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<IEnumerable<CompanyResponse>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        List<Company> companies = await dbContext.Companies.ToListAsync(cancellationToken);

        foreach (var company in companies)
        {
            if (company.ContractEndDate < DateTime.Now)
                company.IsActive = false;
        }

        var response = mapper.Map<IEnumerable<CompanyResponse>>(companies);

        return new ApiResponse<IEnumerable<CompanyResponse>>(response);
    }
}
