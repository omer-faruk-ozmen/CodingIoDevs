using CodingIoDevs.Application.Features.ProgrammingLanguages.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, bool>
{
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;


    public DeleteProgrammingLanguageCommandHandler(ProgrammingLanguageBusinessRules programmingLanguageBusinessRules, IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task<bool> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        ProgrammingLanguage? dbLanguage = await _programmingLanguageRepository.GetAsync(l => l.Id == request.Id);

        _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(dbLanguage);

        await _programmingLanguageRepository.DeleteAsync(dbLanguage);

        return true;
    }
}