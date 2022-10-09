using CodingIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using CodingIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using CodingIoDevs.Application.Features.OperationClaims.Models;
using CodingIoDevs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CodingIoDevs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : BaseController
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new()
        {
            PageRequest = pageRequest
        };

        OperationClaimListModel response = await Mediator.Send(getListOperationClaimQuery);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        var result = await Mediator.Send(createOperationClaimCommand);

        return Created("", result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        var result = await Mediator.Send(deleteOperationClaimCommand);

        return Ok(result);
    }
}