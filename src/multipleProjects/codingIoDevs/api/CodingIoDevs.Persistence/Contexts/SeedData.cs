using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.Persistence.Contexts
{
    public class SeedData
    {

        //Todo Fake Data will be created. With Bogus! or similar


        private static List<ProgrammingLanguage> GetLanguages()
        {
            var result = new List<ProgrammingLanguage>()
            {
                new ProgrammingLanguage(Guid.NewGuid(), "C#"),
                new ProgrammingLanguage(Guid.NewGuid(), "Java"),
                new ProgrammingLanguage(Guid.NewGuid(), "Python"),
            };


            return result;
        }

        public async Task SeedAsync()
        {
            var dbContextBuilder = new DbContextOptionsBuilder();



            dbContextBuilder.UseNpgsql(Configuration.ConnectionString);

            var context = new BaseDbContext(dbContextBuilder.Options);

            if (context.ProgrammingLanguages.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var languages = GetLanguages();
            await context.ProgrammingLanguages.AddRangeAsync(languages);

            await context.SaveChangesAsync();
        }
    }
}
