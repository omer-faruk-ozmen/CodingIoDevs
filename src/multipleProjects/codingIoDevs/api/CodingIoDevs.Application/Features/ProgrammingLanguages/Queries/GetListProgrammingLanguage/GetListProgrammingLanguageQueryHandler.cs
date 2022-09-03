using AutoMapper;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Models;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, GetListProgrammingLanguageModel>
{

    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task<GetListProgrammingLanguageModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        //Todo Will look into for correction. Page size is always sent as 0 by from query.
        _programmingLanguageBusinessRules.WillBeDoneIfPageSizeIsZero(request.PageRequest);

        IPaginate<ProgrammingLanguage> languages =
            await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

        GetListProgrammingLanguageModel mappedListLanguageModel =
            _mapper.Map<GetListProgrammingLanguageModel>(languages);
        return mappedListLanguageModel;
    }
}