
using CodingIoDevs.Application.Features.Frameworks.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.CreateFramework;

public class CreateFrameworkCommand : IRequest<CreatedFrameworkDto>
{
    public string Name { get; set; }
    public Guid ProgrammingLanguageId { get; set; }
}