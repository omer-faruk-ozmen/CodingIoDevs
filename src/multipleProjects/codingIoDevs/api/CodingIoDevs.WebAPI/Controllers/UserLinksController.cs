using CodingIoDevs.Application.Features.UserLinks.Commands.CreateUserLink;
using CodingIoDevs.Application.Features.UserLinks.Commands.UpdateUserLink;
using CodingIoDevs.Application.Features.UserLinks.Dtos;
using CodingIoDevs.Application.Features.UserLinks.Queries.GetByIdUserLink;
using CodingIoDevs.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingIoDevs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserLinksController : BaseController
{
    [HttpGet("{UserId}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserLinkQuery getByIdUserLinkQuery)
    {
        GetByIdUserLinkDto result = await Mediator.Send(getByIdUserLinkQuery);

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] CreateUserLinkCommand createUserLinkCommand)
    {
        CreatedUserLinkDto result = await Mediator.Send(createUserLinkCommand);

        return Created("", result);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateUserLinkCommand updateUserLinkCommand)
    {
        Guid result = await Mediator.Send(updateUserLinkCommand);

        return Ok(result);
    }
}