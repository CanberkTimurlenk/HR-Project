using HR.Base.Response;
using HR.Business.Companies.Commands.Create;
using HR.Business.Companies.Commands.Delete;
using HR.Business.Features.Companies.Queries.GetById;
using HR.Business.Features.Companies.Queries.GetByParameter;
using HR.Business.Users.Commands.Create;
using HR.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace HR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;


    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<IEnumerable<CompanyResponse>>> Get()
    {
        return await mediator.Send(new GetAllCompaniesQuery());
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<CompanyResponse>> GetById(int id)
    {
        return await mediator.Send(new GetCompanyByIdQuery(id));
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Create(IFormFile LogoFile, [FromForm] CreateCompanyCommandRequest request)
    {

        var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Companies", "Logos");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var LogoFileName = Guid.NewGuid().ToString() + Path.GetExtension(LogoFile.FileName);
        var path = Path.Combine(folder, LogoFileName);

        await using (var stream = new FileStream(path, FileMode.Create))
            await LogoFile.CopyToAsync(stream);

        var result = await mediator.Send(new CreateCompanyCommand(LogoFileName, request));

        if (result == null)
        {
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            return new ApiResponse("Bad Request!");
        }
        return new ApiResponse();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse> Delete(int id)
    {
        return await mediator.Send(new DeleteCompanyCommand(id));
    }

    [HttpGet("get-logo")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Download(string fileName)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", "Companies", "Logos", fileName);

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(fileName, out var contentType))
            contentType = "application/octet-stream";

        var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(bytes, contentType, Path.GetFileName(filePath));
    }

   

}
