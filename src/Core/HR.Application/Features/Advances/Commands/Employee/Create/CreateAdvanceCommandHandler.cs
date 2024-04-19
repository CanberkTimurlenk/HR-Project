using AutoMapper;
using MediatR;
using HR.Schema.Response;
using HR.Application.Contracts.Repositories.Advances;
using HR.Application.Contracts.Repositories.Employees;
using HR.Domain.Entities.Concrete;
using HR.Domain.Enums;

namespace HR.Application.Features.Advances.Commands.Employee.Create;
public class CreateAdvanceCommandHandler(IAdvanceRepository advanceRepository, IEmployeeRepository employeeRepository, IMapper mapper) :
    IRequestHandler<CreateAdvanceCommand, ApiResponse>
{

    private readonly IAdvanceRepository advanceRepository = advanceRepository;
    private readonly IEmployeeRepository employeeRepository = employeeRepository;
    private readonly IMapper mapper = mapper;

    public async Task<ApiResponse> Handle(CreateAdvanceCommand request, CancellationToken cancellationToken)
    {
        var advance = mapper.Map<Advance>(request.Model);

        var salary = await employeeRepository.GetSalaryByEmployeeIdAsync(request.EmployeeId, cancellationToken);

        if (advance.Amount > salary * 3)
            return new ApiResponse("You can not request more than 3 times your salary");

        advance.ApprovalStatus = ApprovalStatus.Pending;
        advance.RequestDate = DateTime.Now;
        advance.CreatorEmployeeId = request.EmployeeId;

        await advanceRepository.AddAsync(advance, cancellationToken);
        await advanceRepository.SaveChangesAsync(cancellationToken);

        return new ApiResponse();
    }
}
