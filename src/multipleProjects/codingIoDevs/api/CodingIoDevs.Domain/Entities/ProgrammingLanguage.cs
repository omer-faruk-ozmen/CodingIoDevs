using Core.Persistence.Repositories;

namespace CodingIoDevs.Domain.Entities;

public class ProgrammingLanguage : Entity
{
    public ProgrammingLanguage()
    { }

    public ProgrammingLanguage(Guid id, string name) 
    {
        Id = id;
        Name = name;
    }
    public string Name { get; set; }
    public virtual ICollection<Framework> Frameworks { get; set; }


}