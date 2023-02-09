namespace AnimalRegistryAPI.Models.Requests
{
    public class UpdateAnimalRequest
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
