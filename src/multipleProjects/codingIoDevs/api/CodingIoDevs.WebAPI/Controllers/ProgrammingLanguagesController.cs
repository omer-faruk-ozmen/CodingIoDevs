using CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Models;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingIoDevs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : BaseController
{


    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {

        GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new()
        {
            PageRequest = pageRequest
        };
        GetListProgrammingLanguageModel result = await Mediator.Send(getListProgrammingLanguageQuery);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery query)
    {
        GetByIdProgrammingLanguageDto result = await Mediator.Send(query);

        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
    {
        CreatedProgrammingLanguageDto result = await Mediator.Send(command);

        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand command)
    {
        var guid = await Mediator.Send(command);
        return Ok(guid);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }
}