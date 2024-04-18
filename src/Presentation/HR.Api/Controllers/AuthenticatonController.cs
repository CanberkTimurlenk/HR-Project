using HR.Api.Helpers;
using HR.Base.Response;
using HR.Business.Features.Authentication.Query;
using HR.Business.Features.Users.Commands.ResetPassword;
using HR.Business.Users.Commands.ChangePassword;
using HR.Business.Users.Commands.ForgetPassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatonController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;

        [HttpPost("login")]
        public async Task<ApiResponse<AuthenticateUserQueryResponse>> Login(AuthenticateUserQuery request)
        {
            return await mediator.Send(request);
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            var result = await mediator.Send(new ForgetPasswordCommand(email));

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("change-password/{guid}")]
        public async Task<IActionResult> ChangePassword(string guid, [FromBody] string password)
        {
            var result = await mediator.Send(new ChangePasswordCommand(guid, password));

            if (result == null)
                return BadRequest();

            return Ok(result);

        }

        [HttpPost("admin-change-password")]
        public async Task<IActionResult> AdminChangePassword([FromBody] ResetPasswordCommand request)
        {
            var result = await mediator.Send(request);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
