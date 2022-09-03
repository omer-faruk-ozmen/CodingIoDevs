using CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
        {


            CreatedProgrammingLanguageDto result = await Mediator.Send(command);

            return Created("", result);
        }
    }
}
