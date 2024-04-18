using HR.Base.Response;
using HR.Business.Features.Expenses.Commands.Employee.Cancel;
using HR.Business.Features.Expenses.Commands.Employee.Create;
using HR.Business.Features.Expenses.Commands.Employee.Update;
using HR.Business.Features.Expenses.Commands.Manager.Approve;
using HR.Business.Features.Expenses.Commands.Manager.Reject;
using HR.Business.Features.Expenses.Queries.GetById;
using HR.Business.Features.Expenses.Queries.GetByParameter;
using HR.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;
using MediatR;

namespace HR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpGet]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse<IEnumerable<ExpenseResponse>>> GetByParameter(int? employeeId)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;

        var operation = new GetExpensesByParameterQuery(employeeId, userId, role);
        return await mediator.Send(operation);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse<ExpenseResponse>> GetById(int id)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;

        var operation = new GetExpenseByIdQuery(userId, id, role);
        return await mediator.Send(operation);
    }

    [HttpPost]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> CreateExpense(IFormFile file, [FromForm] CreateExpenseCommandRequest request)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);

        var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Expenses");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var path = Path.Combine(folder, fileName);

        await using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        var operation = new CreateExpenseCommand(userId, fileName, request);
        return await mediator.Send(operation);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> UpdateExpense(int id, UpdateExpenseCommandRequest request)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);

        var operation = new UpdateExpenseCommand(userId, id, request);
        return await mediator.Send(operation);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "employee")]
    public async Task<ApiResponse> DeleteExpense(int id)
    {
        var userId = Convert.ToInt32((User.Identity as ClaimsIdentity).FindFirst("id").Value);

        var operation = new CancelExpenseCommand(userId, id);
        return await mediator.Send(operation);
    }

    [HttpPost("approve")]
    [Authorize(Roles = "manager")]
    public async Task<ApiResponse> Approve(ICollection<int> id)
    {
        var operation = new ApproveExpenseCommand(id);
        return await mediator.Send(operation);
    }

    [HttpPost("reject")]
    [Authorize(Roles = "manager")]
    public async Task<ApiResponse> Reject(ICollection<int> id)
    {
        var operation = new RejectExpenseCommand(id);
        return await mediator.Send(operation);
    }

    [HttpGet("get-file")]
    [Authorize(Roles = "employee,manager")]
    public async Task<IActionResult> Download(string fileName)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Expenses", fileName);

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(fileName, out var contentType))
            contentType = "application/octet-stream";

        var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(bytes, contentType, Path.GetFileName(filePath));
    }
}
