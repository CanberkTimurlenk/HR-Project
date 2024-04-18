using HR.Data.Contexts;
using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Companies.Commands.Delete;

public class DeleteCompanyCommandHandler(HrDbContext dbContext) : IRequestHandler<DeleteCompanyCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    public async Task<ApiResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await dbContext.Companies.FindAsync([request.Id], cancellationToken);

        if (company == null)
            return new ApiResponse("Not Found!");

        company.IsActive = false;
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
