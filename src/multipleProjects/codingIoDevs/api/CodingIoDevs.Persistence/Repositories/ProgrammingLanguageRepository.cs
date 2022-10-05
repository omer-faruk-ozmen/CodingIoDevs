using Core.Persistence.Repositories;
using CodingIoDevs.Persistence.Contexts;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;

namespace CodingIoDevs.Persistence.Repositories;

public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
{
    public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}