using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.Frameworks.Rules
{
    public class FrameworkBusinessRules
    {
        private readonly IFrameworkRepository _frameworkRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public FrameworkBusinessRules(IFrameworkRepository frameworkRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _frameworkRepository = frameworkRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }


        public async Task FrameworkNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Framework> result = await _frameworkRepository.GetListAsync(f => f.Name == name);
            
            if (result.Items.Any())
                throw new BusinessException("Framework name exists!");
        }

        public async Task ValidForeignKeyField(Guid programmingLanguageId)
        {
            ProgrammingLanguage? result =
                await _programmingLanguageRepository.GetAsync(p => p.Id == programmingLanguageId);

            if (result == null)
                throw new BusinessException("Programming Language Id not found!");
        }

        public void FrameworkShouldExistWhenRequested(Framework? dbFramework)
        {
            if (dbFramework == null) throw new BusinessException("Requested framework does not exists");
        }

    }
}
