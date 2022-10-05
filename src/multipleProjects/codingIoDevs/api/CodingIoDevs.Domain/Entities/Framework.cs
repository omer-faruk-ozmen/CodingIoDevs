using Core.Persistence.Repositories;

namespace CodingIoDevs.Domain.Entities;

public class Framework : Entity
{
    public Guid ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

    public Framework()
    {

    }

    public Framework(Guid id, Guid programmingLanguageId, string name) : this()
    {
        Id = id;
        ProgrammingLanguageId = programmingLanguageId;
        Name = name;
    }
}