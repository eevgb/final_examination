using AnimalRegistryAPI.Models;

namespace AnimalRegistryAPI.Services
{
    public interface IAnimalRepository : IRepository<Animal, int>
    {
    }
}
