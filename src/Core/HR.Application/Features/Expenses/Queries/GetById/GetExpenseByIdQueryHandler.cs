using AutoMapper;
using HR.Data.Contexts;
using HR.Schema.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.Expenses.Queries.GetById;

public class GetExpenseByIdQueryHandler(HrDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetExpenseByIdQuery, ApiResponse<ExpenseResponse>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse<ExpenseResponse>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var leave = await dbContext.Expenses.Include(x => x.CreatorEmployee)
            .SingleOrDefaultAsync(x => x.Id == request.ExpenseId, cancellationToken: cancellationToken);

        if (leave?.CreatorEmployeeId != request.EmployeeId)
            return new ApiResponse<ExpenseResponse>("You have not access to this expense");

        var response = mapper.Map<ExpenseResponse>(leave);

        return new ApiResponse<ExpenseResponse>(response);
    }
}
