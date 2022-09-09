using CodingIoDevs.Application.Features.UserLinks.Commands.CreateUserLink;
using CodingIoDevs.Application.Features.UserLinks.Commands.UpdateUserLink;
using CodingIoDevs.Application.Features.UserLinks.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserLinksController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserLinkCommand createUserLinkCommand)
        {
            CreatedUserLinkDto result = await Mediator.Send(createUserLinkCommand);

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserLinkCommand updateUserLinkCommand)
        {
            Guid result = await Mediator.Send(updateUserLinkCommand);

            return Ok(result);
        }
    }
}
