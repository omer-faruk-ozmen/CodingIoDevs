using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Domain.Entities;
using Core.Persistence.Repositories;

namespace CodingIoDevs.Application.Services.Repositories;

public interface IFrameworkRepository : IAsyncRepository<Framework>, IRepository<Framework>
{
}