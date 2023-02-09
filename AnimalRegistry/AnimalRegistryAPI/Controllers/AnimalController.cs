using AnimalRegistryAPI.Models.Requests;
using AnimalRegistryAPI.Models;
using AnimalRegistryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalRegistryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateAnimal")]
        public ActionResult<int> Create([FromBody] CreateAnimalRequest createRequest)
        {
            int res = _animalRepository.Create(new Animal
            {
                Name = createRequest.Name,
                Birthday = createRequest.Birthday,
                Description = createRequest.Description,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateAnimal")]
        public ActionResult<int> Update([FromBody] UpdateAnimalRequest updateRequest)
        {
            int res = _animalRepository.Update(new Animal
            {
                AnimalId = updateRequest.AnimalId,
                Name = updateRequest.Name,
                Birthday = updateRequest.Birthday,
                Description = updateRequest.Description,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteAnimal")]
        public ActionResult<int> Delete(int animalId)
        {
            int res = _animalRepository.Delete(animalId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllAnimals")]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_animalRepository.GetAll());
        }

        [HttpGet("get-all-by-kind-of-animal-id")]
        [SwaggerOperation(OperationId = "GetAllAnimalsByKindOfAnimalId")]
        public ActionResult<List<Animal>> GetAllByKindOfAnimalId(int id)
        {
            return Ok(_animalRepository.GetAllByKindOfAnimalId(id));
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetAnimalById")]
        public ActionResult<Animal> GetById(int animalId)
        {
            return Ok(_animalRepository.GetById(animalId));
        }
    }
}
