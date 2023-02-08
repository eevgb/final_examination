namespace AnimalRegistryAPI.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public int KindOfAnimalId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
