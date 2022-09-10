using CodingIoDevs.Application.Features.Frameworks.Commands.CreateFramework;
using CodingIoDevs.Application.Features.Frameworks.Commands.DeleteFramework;
using CodingIoDevs.Application.Features.Frameworks.Commands.UpdateFramework;
using CodingIoDevs.Application.Features.Frameworks.Dtos;
using CodingIoDevs.Application.Features.Frameworks.Models;
using CodingIoDevs.Application.Features.Frameworks.Queries.GetListFramework;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FrameworksController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFrameworkQuery getListFrameworkQuery = new() { PageRequest = pageRequest };

        FrameworkListModel result = await Mediator.Send(getListFrameworkQuery);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFrameworkCommand createFrameworkCommand)
    {
        CreatedFrameworkDto result = await Mediator.Send(createFrameworkCommand);

        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFrameworkCommand updateFrameworkCommand)
    {
        Guid result = await Mediator.Send(updateFrameworkCommand);

        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteFrameworkCommand deleteFrameworkCommand)
    {
        bool result = await Mediator.Send(deleteFrameworkCommand);

        return Ok(result);
    }


}