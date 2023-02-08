namespace AnimalRegistryAPI.Models.Requests
{
    public class CreateAnimalRequest
    {
        public int KindOfAnimalId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
