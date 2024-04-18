using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using HR.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Business.Users.Queries.GetByParameter;

public class GetUserByParameterQueryHandler(HrDbContext dbContext, IMapper mapper) : IRequestHandler<GetUserByParameterQuery, ApiResponse<IEnumerable<UserResponse>>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<IEnumerable<UserResponse>>> Handle(GetUserByParameterQuery request, CancellationToken cancellationToken)
    {
        //List<User> user = string.IsNullOrEmpty(request.Role)
        //        ? await dbContext.Users.Include(u => u.Leaves).Include(u => u.Expenses).Include(u => u.Advances).ToListAsync(cancellationToken)
        //        : await dbContext.Users.Where(u => u.Role == request.Role).Include(u => u.Leaves).Include(u => u.Advances).Include(u => u.Expenses).ToListAsync(cancellationToken);

        //var response = mapper.Map<IEnumerable<UserResponse>>(user);

        //return new ApiResponse<IEnumerable<UserResponse>>(response);

        return null;
    }
}
