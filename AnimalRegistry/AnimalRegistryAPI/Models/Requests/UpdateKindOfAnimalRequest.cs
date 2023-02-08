namespace AnimalRegistryAPI.Models.Requests
{
    public class UpdateKindOfAnimalRequest
    {
        public int KindOfAnimalId { get; set; }
        public string? Kind { get; set; }
    }
}
