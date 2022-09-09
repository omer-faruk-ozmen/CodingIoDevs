using CodingIoDevs.Application.Features.Frameworks.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.DeleteFramework;

public class DeleteFrameworkCommandHandler : IRequestHandler<DeleteFrameworkCommand, bool>
{
    private readonly IFrameworkRepository _frameworkRepository;
    private readonly FrameworkBusinessRules _frameworkBusinessRules;

    public DeleteFrameworkCommandHandler(IFrameworkRepository frameworkRepository, FrameworkBusinessRules frameworkBusinessRules)
    {
        _frameworkRepository = frameworkRepository;
        _frameworkBusinessRules = frameworkBusinessRules;
    }

    public async Task<bool> Handle(DeleteFrameworkCommand request, CancellationToken cancellationToken)
    {
        Framework? dbFramework = await _frameworkRepository.GetAsync(p => p.Id == request.Id);

        _frameworkBusinessRules.FrameworkShouldExistWhenRequested(dbFramework);

        await _frameworkRepository.DeleteAsync(dbFramework);

        return true;
    }
}