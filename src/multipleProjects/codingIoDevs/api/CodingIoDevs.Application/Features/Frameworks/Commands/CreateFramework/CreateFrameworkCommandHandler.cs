using AutoMapper;
using CodingIoDevs.Application.Features.Frameworks.Dtos;
using CodingIoDevs.Application.Features.Frameworks.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.CreateFramework;

public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreatedFrameworkDto>
{
    private readonly IMapper _mapper;
    private readonly FrameworkBusinessRules _frameworkBusinessRules;
    private readonly IFrameworkRepository _frameworkRepository;

    public CreateFrameworkCommandHandler(IMapper mapper, FrameworkBusinessRules frameworkBusinessRules, IFrameworkRepository frameworkRepository)
    {
        _mapper = mapper;
        _frameworkBusinessRules = frameworkBusinessRules;
        _frameworkRepository = frameworkRepository;
    }

    public async Task<CreatedFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
    {
        await _frameworkBusinessRules.FrameworkNameCanNotBeDuplicatedWhenInserted(request.Name);
        await _frameworkBusinessRules.ValidForeignKeyField(request.ProgrammingLanguageId);
        Framework mappedFramework = _mapper.Map<Framework>(request);

        Framework createdFramework = await _frameworkRepository.AddAsync(mappedFramework);

        CreatedFrameworkDto response = _mapper.Map<CreatedFrameworkDto>(createdFramework);

        return response;
    }
}