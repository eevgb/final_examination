using AnimalRegistryAPI.Models;

namespace AnimalRegistryAPI.Services
{
    public interface IAnimalSkillRepository : IRepository<AnimalSkill, int>
    {
        IList<AnimalSkill> GetAllByAnimalId(int id);
        IList<AnimalSkill> GetAllBySkillId(int id);
    }
}
