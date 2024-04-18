using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using HR.Data.Entities;
using HR.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Users.Queries.GetByParameter;

public class GetUserByIdQueryHandler(HrDbContext dbContext, IMapper mapper) : IRequestHandler<GetUserByIdQuery, ApiResponse<UserResponse>>
{

    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        //var user = await dbContext.Users.AsNoTracking()
        //    .Include(u => u.Leaves)
        //    .Include(u => u.Expenses)
        //    .Include(u => u.Advances)
        //    .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        //if (user == null)
        //    return new ApiResponse<UserResponse>("Not Found!");

        //var response = mapper.Map<UserResponse>(user);


        //return new ApiResponse<UserResponse>(data: response);

        return null;
    }
}
