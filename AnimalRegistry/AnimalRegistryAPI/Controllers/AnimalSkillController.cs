using AnimalRegistryAPI.Models.Requests;
using AnimalRegistryAPI.Models;
using AnimalRegistryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalRegistryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalSkillController : ControllerBase
    {
        private IAnimalSkillRepository _animalSkillRepository;

        public AnimalSkillController(IAnimalSkillRepository animalSkillRepository)
        {
            _animalSkillRepository = animalSkillRepository;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateAnimalSkill")]
        public ActionResult<int> Create([FromBody] CreateAnimalSkillRequest createRequest)
        {
            int res = _animalSkillRepository.Create(new AnimalSkill
            {
                AnimalId = createRequest.AnimalId,
                SkilId = createRequest.SkilId,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateAnimalSkill")]
        public ActionResult<int> Update([FromBody] UpdateAnimalSkillRequest updateRequest)
        {
            int res = _animalSkillRepository.Update(new AnimalSkill
            {
                AnimalSkillId = updateRequest.AnimalSkillId,
                AnimalId = updateRequest.AnimalId,
                SkilId = updateRequest.SkilId,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteAnimalSkill")]
        public ActionResult<int> Delete(int animalSkillId)
        {
            int res = _animalSkillRepository.Delete(animalSkillId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllAnimalSkills")]
        public ActionResult<List<AnimalSkill>> GetAll()
        {
            return Ok(_animalSkillRepository.GetAll());
        }

        [HttpGet("get-all-by-animal-id")]
        [SwaggerOperation(OperationId = "GetAllAnimalSkillsByAnimalId")]
        public ActionResult<List<AnimalSkill>> GetAllByAnimalId(int id)
        {
            return Ok(_animalSkillRepository.GetAllByAnimalId(id));
        }

        [HttpGet("get-all-by-skill-id")]
        [SwaggerOperation(OperationId = "GetAllAnimalSkillsBySkillId")]
        public ActionResult<List<AnimalSkill>> GetAllBySkillId(int id)
        {
            return Ok(_animalSkillRepository.GetAllBySkillId(id));
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetAnimalSkillById")]
        public ActionResult<AnimalSkill> GetById(int animalSkillId)
        {
            return Ok(_animalSkillRepository.GetById(animalSkillId));
        }
    }
}
