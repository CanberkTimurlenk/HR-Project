using HR.Base.Response;
using HR.Data.Contexts;
using MediatR;

namespace HR.Business.Companies.Commands.Update;

public class UpdateCompanyCommandHandler(HrDbContext dbContext)
    : IRequestHandler<UpdateCompanyCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;

    public async Task<ApiResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await dbContext.Companies.FindAsync([request.Id], cancellationToken);

        if (company == null)
            return new ApiResponse("Not Found!");

        company.PhoneNumber = request.Model.PhoneNumber;
        company.LogoFile = request.LogoFile;
        //company.Address = request.Model.Address;

        await dbContext.SaveChangesAsync(cancellationToken);
        return new ApiResponse();
    }
}