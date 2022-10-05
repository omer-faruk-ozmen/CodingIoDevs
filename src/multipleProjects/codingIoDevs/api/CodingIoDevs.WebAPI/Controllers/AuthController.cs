﻿using CodingIoDevs.Application.Features.Auth.Commands.Login;
using CodingIoDevs.Application.Features.Auth.Commands.Register;
using CodingIoDevs.Application.Features.Auth.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodingIoDevs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        LoginCommand loginCommand = new()
        {
            IpAddress = GetIpAddress(),
            UserForLoginDto = userForLoginDto
        };

        LoginDto result = await Mediator.Send(loginCommand);

        SetRefreshTokenToCookie(result.RefreshToken);

        return Ok(result.AccessToken);

    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        RegisterCommand registerCommand = new()
        {
            UserForRegisterDto = userForRegisterDto,
            IpAddress = GetIpAddress()
        };

        RegisteredDto result = await Mediator.Send(registerCommand);

        SetRefreshTokenToCookie(result.RefreshToken);

        return Created("", result.AccessToken);
    }

    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}