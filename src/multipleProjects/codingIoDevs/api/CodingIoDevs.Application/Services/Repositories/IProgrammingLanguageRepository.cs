using CodingIoDevs.Domain.Entities;
using Core.Persistence.Repositories;

namespace CodingIoDevs.Application.Services.Repositories;

public interface IProgrammingLanguageRepository : IAsyncRepository<ProgrammingLanguage>,IRepository<ProgrammingLanguage>
{
}