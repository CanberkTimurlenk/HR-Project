using AutoMapper;
using HR.Base.Response;
using HR.Data.Contexts;
using MediatR;
using HR.Data.Enums;
using HR.Data.Entities.Concrete;

namespace HR.Business.Features.Expenses.Commands.Employee.Create;
public class CreateExpenseCommandHandler(HrDbContext dbContext, IMapper mapper) :
    IRequestHandler<CreateExpenseCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = mapper.Map<Expense>(request.Model);

        expense.ApprovalStatus = ApprovalStatus.Pending;
        expense.RequestDate = DateTime.Now;
        //expense.File = request.File;
        expense.CreatorEmployeeId = request.EmployeeId;

        await dbContext.Expenses.AddAsync(expense, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
