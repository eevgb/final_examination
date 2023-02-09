using AnimalRegistryAPI.Models.Requests;
using AnimalRegistryAPI.Models;
using AnimalRegistryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalRegistryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateSkill")]
        public ActionResult<int> Create([FromBody] CreateSkillRequest createRequest)
        {
            int res = _skillRepository.Create(new Skill
            {
                KindOfAnimalId = createRequest.KindOfAnimalId,
                CharacterSkill = createRequest.CharacterSkill,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateSkill")]
        public ActionResult<int> Update([FromBody] UpdateSkillRequest updateRequest)
        {
            int res = _skillRepository.Update(new Skill
            {
                SkillId = updateRequest.SkillId,
                KindOfAnimalId = updateRequest.KindOfAnimalId,
                CharacterSkill = updateRequest.CharacterSkill,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteSkill")]
        public ActionResult<int> Delete(int skillId)
        {
            int res = _skillRepository.Delete(skillId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllSkills")]
        public ActionResult<List<Skill>> GetAll()
        {
            return Ok(_skillRepository.GetAll());
        }

        [HttpGet("get-all-by-animal-kind-id")]
        [SwaggerOperation(OperationId = "GetAllSkillsByAnimalKindId")]
        public ActionResult<List<Skill>> GetAllByAnimalKindId(int id)
        {
            return Ok(_skillRepository.GetAllByAnimalKindId(id));
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetSkillById")]
        public ActionResult<Skill> GetById(int skillId)
        {
            return Ok(_skillRepository.GetById(skillId));
        }
    }
}
