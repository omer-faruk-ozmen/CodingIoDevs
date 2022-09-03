using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result =
                await _programmingLanguageRepository.GetListAsync(b => b.Name == name);

            if (result.Items.Any()) throw new BusinessException("Language name exists");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage language)
        {
            if (language == null) throw new BusinessException("Requested language does not exists");
        }

        public void WillBeDoneIfPageSizeIsZero(PageRequest pageRequest)
        {
            if (pageRequest.PageSize == 0)
                pageRequest.PageSize = 10;

        }



    }
}
