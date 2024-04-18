using HR.Base.Response;
using HR.Business.Users.Commands.Create;
using HR.Business.Users.Commands.Update;
using HR.Business.Users.Queries.GetByParameter;
using HR.Data.Entities;
using HR.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;

namespace HR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;


    [HttpGet]
    [Authorize(Roles = "manager")]
    public async Task<IActionResult> Get([FromQuery] string? role)
    {
        var managers = await mediator.Send(new GetUserByParameterQuery(role));

        if (managers == null)
            return NotFound();

        return Ok(managers);

    }

    [HttpPut("{id}")]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse> Update(int id, IFormFile photo, [FromForm] UpdateUserCommandRequest request)
    {
        var userId = (User.Identity as ClaimsIdentity).FindFirst("id").Value;
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;

        if (role == "employee" && userId != id.ToString())
            return new ApiResponse("Unauthorized!");

        var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Users");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var photoName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
        var path = Path.Combine(folder, photoName);

        await using (var stream = new FileStream(path, FileMode.Create))
            await photo.CopyToAsync(stream);

        return await mediator.Send(new UpdateUserCommand(id, photoName, request));

    }

    [HttpGet("{id}")]
    [Authorize(Roles = "employee,manager")]
    public async Task<ApiResponse<UserResponse>> GetById(int id)
    {
        var userId = (User.Identity as ClaimsIdentity).FindFirst("id").Value;
        var role = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;


        if (role == "employee" && userId != id.ToString())
            return new ApiResponse<UserResponse>("Unauthorized!");

        var manager = await mediator.Send(new GetUserByIdQuery(id));

        return manager ?? new ApiResponse<UserResponse>("Not Found!");
    }

    [HttpGet("get-picture")]
    [Authorize(Roles = "manager,employee")]
    public async Task<IActionResult> Download(string fileName)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Users", fileName);

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(fileName, out var contentType))
            contentType = "application/octet-stream";

        var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(bytes, contentType, Path.GetFileName(filePath));
    }

    [HttpPost]
    [Authorize(Roles = "manager")]
    public async Task<ApiResponse> AddAsync(IFormFile photo, [FromForm] CreateUserCommandRequest request)
    {
        var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Users");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var photoName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
        var path = Path.Combine(folder, photoName);

        await using (var stream = new FileStream(path, FileMode.Create))
            await photo.CopyToAsync(stream);

        var result = await mediator.Send(new CreateUserCommand(photoName, request));

        if (result == null)
        {
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            return new ApiResponse("Bad Request!");
        }
        return new ApiResponse();
    }
}