using AutoMapper;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await _programmingLanguageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

        

        ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);

        ProgrammingLanguage createdLanguage = await _programmingLanguageRepository.AddAsync(mappedLanguage);

        CreatedProgrammingLanguageDto response = _mapper.Map<CreatedProgrammingLanguageDto>(createdLanguage);

        return response;
    }
}