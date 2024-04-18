using AutoMapper;
using HR.Data.Contexts;
using HR.Domain.Entities.Concrete;
using HR.Schema.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.Expenses.Queries.GetByParameter;

public class GetExpensesByParameterQueryHandler(HrDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetExpensesByParameterQuery, ApiResponse<IEnumerable<ExpenseResponse>>>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;
    public async Task<ApiResponse<IEnumerable<ExpenseResponse>>> Handle(GetExpensesByParameterQuery request, CancellationToken cancellationToken)
    {
        if (request.Role == "employee" && request.UserId != request.EmployeeId)
            return new ApiResponse<IEnumerable<ExpenseResponse>>("You have not access to expenses");


        IQueryable<Expense> query = dbContext.Expenses.Include(x => x.CreatorEmployee);

        if (request.EmployeeId != null)
            query = query.Where(x => x.CreatorEmployeeId == request.EmployeeId);

        var leaves = await query.ToListAsync(cancellationToken: cancellationToken);

        var response = mapper.Map<IEnumerable<ExpenseResponse>>(leaves);

        return new ApiResponse<IEnumerable<ExpenseResponse>>(data: response);
    }
}
