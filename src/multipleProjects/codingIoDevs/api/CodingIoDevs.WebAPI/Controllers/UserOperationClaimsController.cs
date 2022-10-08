using CodingIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using CodingIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;
using CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CodingIoDevs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "admin,moderator")]
public class UserOperationClaimsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
    {
        GetListUserOperationClaimQuery getListUserOperationClaimQuery = new()
        {
            PageRequest = pageRequest
        };

        UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimQuery);

        return Ok(result);

    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserId([FromQuery] PageRequest pageRequest, [FromRoute] Guid userId)
    {
        GetByUserIdUserOperationClaimQuery getByUserIdUserOperationClaimQuery = new()
        {
            PageRequest = pageRequest,
            UserId = userId
        };

        UserOperationClaimSingleModel result = await Mediator.Send(getByUserIdUserOperationClaimQuery);

        return Ok(result);

    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);

        return Created("", result);

    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
    {
        DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);

        return Ok(result);

    }

}