using AutoMapper;
using CodingIoDevs.Application.Features.Frameworks.Models;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.Application.Features.Frameworks.Queries.GetListFramework;

public class GetListFrameworkQueryHandler : IRequestHandler<GetListFrameworkQuery, FrameworkListModel>
{
    private readonly IMapper _mapper;
    private readonly IFrameworkRepository _frameworkRepository;

    public GetListFrameworkQueryHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
    {
        _mapper = mapper;
        _frameworkRepository = frameworkRepository;
    }

    public async Task<FrameworkListModel> Handle(GetListFrameworkQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Framework> frameworks =
            await _frameworkRepository
                .GetListAsync(include: p => p.Include(c => c.ProgrammingLanguage),
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);

        FrameworkListModel mappedFramework = _mapper.Map<FrameworkListModel>(frameworks);

        return mappedFramework;
    }
}