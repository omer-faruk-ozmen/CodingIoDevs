using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingIoDevs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    private IMediator? _mediator;
}