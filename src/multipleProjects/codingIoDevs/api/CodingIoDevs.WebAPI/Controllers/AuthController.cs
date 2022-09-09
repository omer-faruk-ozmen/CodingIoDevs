using CodingIoDevs.Application.Features.Auth.Commands.Login;
using CodingIoDevs.Application.Features.Auth.Commands.Register;
using CodingIoDevs.Application.Features.Auth.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            LoginUserDto loginUserDto = await Mediator.Send(loginUserCommand);
            return Ok(loginUserDto);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            RegisterUserDto registerUserDto = await Mediator.Send(registerUserCommand);
            return Ok(registerUserDto);
        }
    }
}
