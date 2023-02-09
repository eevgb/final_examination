using AnimalRegistryAPI.Models;
using AnimalRegistryAPI.Models.Requests;
using AnimalRegistryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AnimalRegistryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindOfAnimalController : ControllerBase
    {
        private IKindOfAnimalRepository _kindOfAnimalRepository;

        public KindOfAnimalController(IKindOfAnimalRepository kindOfAnimalRepository)
        {
            _kindOfAnimalRepository = kindOfAnimalRepository;
        }

        [HttpPost("create")]
        [SwaggerOperation(OperationId = "CreateKindOfAnimal")]
        public ActionResult<int> Create([FromBody] CreateKindOfAnimalRequest createRequest)
        {
            int res = _kindOfAnimalRepository.Create(new KindOfAnimal
            {
                Kind = createRequest.Kind,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "UpdateKindOfAnimal")]
        public ActionResult<int> Update([FromBody] UpdateKindOfAnimalRequest updateRequest)
        {
            int res = _kindOfAnimalRepository.Update(new KindOfAnimal
            {
                KindOfAnimalId = updateRequest.KindOfAnimalId,
                Kind = updateRequest.Kind,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "DeleteKindOfAnimal")]
        public ActionResult<int> Delete(int KindOfAnimalId)
        {
            int res = _kindOfAnimalRepository.Delete(KindOfAnimalId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "GetAllKindsOfAnimal")]
        public ActionResult<List<KindOfAnimal>> GetAll()
        {
            return Ok(_kindOfAnimalRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        [SwaggerOperation(OperationId = "GetKindOfAnimalById")]
        public ActionResult<KindOfAnimal> GetById(int KindOfAnimalId)
        {
            return Ok(_kindOfAnimalRepository.GetById(KindOfAnimalId));
        }
    }
}
