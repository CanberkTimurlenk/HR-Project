using HR.Base.Response;
using HR.Business.Features.Advances.Commands.Employee.Cancel;
using HR.Business.Features.Advances.Commands.Employee.Create;
using HR.Business.Features.Advances.Commands.Employee.Update;
using HR.Business.Features.Advances.Commands.Manager.Approve;
using HR.Business.Features.Advances.Commands.Manager.Reject;
using HR.Business.Features.Advances.Queries.GetById;
using HR.Business.Features.Advances.Queries.GetByParameter;
using HR.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvancesController(IMediator mediator) : ControllerBase
{

    private readonly IMediator mediator = mediator;
    [HttpGet]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse<IEnumerable<AdvanceResponse>>> GetByParameter(int? employeeId)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;

        var operation = new GetAdvancesByParameterQuery(employeeId, userId, role);
        return await mediator.Send(operation);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse<AdvanceResponse>> GetById(int id)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;

        var operation = new GetAdvanceByIdQuery(userId, id, role);
        return await mediator.Send(operation);
    }

    [HttpPost]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> CreateAdvance(CreateAdvanceCommandRequest request)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var operation = new CreateAdvanceCommand(userId, request);

        return await mediator.Send(operation);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> UpdateAdvance(int id, UpdateAdvanceCommandRequest request)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);

        var operation = new UpdateAdvanceCommand(userId, id, request);
        return await mediator.Send(operation);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> DeleteAdvance(int id)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);

        var operation = new CancelAdvanceCommand(userId, id);
        return await mediator.Send(operation);
    }

    [HttpPost("approve")]
    [Authorize(Roles = "manager")]
    public async Task<ApiResponse> Approve(ICollection<int> id)
    {
        var operation = new ApproveAdvanceCommand(id);
        return await mediator.Send(operation);
    }

    [HttpPost("reject")]
    [Authorize(Roles = "manager")]
    public async Task<ApiResponse> Reject(ICollection<int> id)
    {
        var operation = new RejectAdvanceCommand(id);
        return await mediator.Send(operation);
    }
}
