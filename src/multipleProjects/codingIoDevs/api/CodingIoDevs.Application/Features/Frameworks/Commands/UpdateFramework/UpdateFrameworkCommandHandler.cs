using AutoMapper;
using CodingIoDevs.Application.Features.Frameworks.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.UpdateFramework;

public class UpdateFrameworkCommandHandler : IRequestHandler<UpdateFrameworkCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IFrameworkRepository _frameworkRepository;
    private readonly FrameworkBusinessRules _frameworkBusinessRules;

    public UpdateFrameworkCommandHandler(IMapper mapper, IFrameworkRepository frameworkRepository, FrameworkBusinessRules frameworkBusinessRules)
    {
        _mapper = mapper;
        _frameworkRepository = frameworkRepository;
        _frameworkBusinessRules = frameworkBusinessRules;
    }

    public async Task<Guid> Handle(UpdateFrameworkCommand request, CancellationToken cancellationToken)
    {
        await _frameworkBusinessRules.FrameworkNameCanNotBeDuplicatedWhenInserted(request.Name);
        await _frameworkBusinessRules.ValidForeignKeyField(request.ProgrammingLanguageId);

        Framework? dbFramework = await _frameworkRepository.GetAsync(p => p.Id == request.Id);

        _frameworkBusinessRules.FrameworkShouldExistWhenRequested(dbFramework);

        _mapper.Map(request, dbFramework);

        await _frameworkRepository.UpdateAsync(dbFramework);

        return dbFramework.Id;
    }
}