using AutoMapper;
using HR.Api.Helpers;
using HR.Base.Response;
using HR.Data.Contexts;
using HR.Data.Entities.Concrete;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace HR.Business.Companies.Commands.Create;

public class CreateCompanyCommandHandler(HrDbContext dbContext, IMapper mapper, IConfiguration configuration) : IRequestHandler<CreateCompanyCommand, ApiResponse<int>>
{
    private readonly IConfiguration configuration = configuration;
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;
    public async Task<ApiResponse<int>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = mapper.Map<Company>(request.Model);

        company.IsActive = request.Model.ContractEndDate > DateTime.Now;
        company.LogoFile = request.FileName;

        await dbContext.Companies.AddAsync(company, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse<int>(company.Id);
    }
}