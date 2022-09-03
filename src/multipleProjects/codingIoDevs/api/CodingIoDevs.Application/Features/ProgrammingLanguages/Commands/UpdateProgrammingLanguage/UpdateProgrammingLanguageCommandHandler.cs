using AutoMapper;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;


    public UpdateProgrammingLanguageCommandHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _mapper = mapper;
        _programmingLanguageRepository = programmingLanguageRepository;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task<Guid> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await _programmingLanguageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

        ProgrammingLanguage dbLanguage = await _programmingLanguageRepository.GetAsync(l => l.Id == request.Id);

        _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(dbLanguage);

        _mapper.Map(request, dbLanguage);

        await _programmingLanguageRepository.UpdateAsync(dbLanguage);

        return dbLanguage.Id;
    }
}