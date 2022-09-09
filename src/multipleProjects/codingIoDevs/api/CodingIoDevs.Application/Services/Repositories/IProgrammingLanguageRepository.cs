using CodingIoDevs.Domain.Entities;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingIoDevs.Application.Services.Repositories;

public interface IProgrammingLanguageRepository : IAsyncRepository<ProgrammingLanguage>,IRepository<ProgrammingLanguage>
{
}