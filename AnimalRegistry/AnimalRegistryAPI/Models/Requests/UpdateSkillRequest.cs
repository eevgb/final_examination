namespace AnimalRegistryAPI.Models.Requests
{
    public class UpdateSkillRequest
    {
        public int SkillId { get; set; }
        public int KindOfAnimalId { get; set; }
        public string CharacterSkill { get; set; }
    }
}
