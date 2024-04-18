using FluentValidation;
using HR.Base.Response;
using HR.Business.Features.Leaves.Commands.Employee.Cancel;
using HR.Business.Features.Leaves.Commands.Employee.Create;
using HR.Business.Features.Leaves.Commands.Employee.Update;
using HR.Business.Features.Leaves.Commands.Manager.Approve;
using HR.Business.Features.Leaves.Commands.Manager.Reject;
using HR.Business.Features.Leaves.Queries.GetById;
using HR.Business.Features.Leaves.Queries.GetByParameter;
using HR.Data.Entities;
using HR.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeavesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpGet]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse<IEnumerable<LeaveResponse>>> GetByParameter(int? employeeId)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;

        var operation = new GetLeavesByParameterQuery(employeeId, userId, role);
        return await mediator.Send(operation);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse<LeaveResponse>> GetById(int id)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;

        var operation = new GetLeaveByIdQuery(userId, id, role);
        return await mediator.Send(operation);
    }

    [HttpPost]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> CreateLeave(CreateLeaveCommandRequest request)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var operation = new CreateLeaveCommand(userId, request);

        return await mediator.Send(operation);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> UpdateLeave(int id, UpdateLeaveCommandRequest request)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);

        var operation = new UpdateLeaveCommand(userId, id, request);
        return await mediator.Send(operation);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> DeleteLeave(int id)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);

        var operation = new CancelLeaveCommand(userId, id);
        return await mediator.Send(operation);
    }

    [HttpPost("approve")]
    [Authorize(Roles = "manager")]
    public async Task<ApiResponse> Approve(ICollection<int> id)
    {
        var operation = new ApproveLeaveCommand(id);
        return await mediator.Send(operation);
    }

    [HttpPost("reject")]
    [Authorize(Roles = "manager")]
    public async Task<ApiResponse> Reject(ICollection<int> id)
    {
        var operation = new RejectLeaveCommand(id);
        return await mediator.Send(operation);
    }
}
