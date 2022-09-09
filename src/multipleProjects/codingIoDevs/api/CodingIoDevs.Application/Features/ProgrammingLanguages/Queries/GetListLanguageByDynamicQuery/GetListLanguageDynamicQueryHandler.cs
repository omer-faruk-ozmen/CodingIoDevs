using AutoMapper;
using CodingIoDevs.Application.Features.Frameworks.Models;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Models;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListLanguageByDynamicQuery;

public class GetListLanguageDynamicQueryHandler : IRequestHandler<GetListLanguageDynamicQuery, GetListProgrammingLanguageModel>
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;


    public GetListLanguageDynamicQueryHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _mapper = mapper;
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task<GetListProgrammingLanguageModel> Handle(GetListLanguageDynamicQuery request, CancellationToken cancellationToken)
    {


        IPaginate<ProgrammingLanguage> languages =
        await _programmingLanguageRepository.GetListByDynamicAsync(dynamic: request.Dynamic, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);

        GetListProgrammingLanguageModel mappedListLanguageModel =
            _mapper.Map<GetListProgrammingLanguageModel>(languages);

        return mappedListLanguageModel;
    }
}