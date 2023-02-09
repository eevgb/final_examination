using AnimalRegistryAPI.Models;

namespace AnimalRegistryAPI.Services
{
    public interface ISkillRepository : IRepository<Skill, int>
    {
        IList<Skill> GetAllByAnimalKindId(int id);
    }
}
