using Lab2GisOpenApiServer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lab2GisOpenApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmStatusController : ControllerBase
    {
        private readonly IAtmStatusRepository _repository;

        public AtmStatusController(IAtmStatusRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ActionName("GetAtm")]
        public ActionResult<AtmStatus> Get(string atmId)
        {
            var atmStatus = _repository.Get(atmId);
            return Ok(atmStatus ?? new AtmStatus { IsWorking = true, Money = 100000 });
        }

        [HttpPut]
        [ActionName("PutAtm")]
        public ActionResult Put(string atmId, AtmStatus atmStatus)
        {
            var existAtmStatus = _repository.Get(atmId);
            if (existAtmStatus == null)
            {
                _repository.Insert(atmId, atmStatus);
            }
            else
            {
                _repository.Update(atmId, atmStatus);
            }
            return Ok();
        }
    }
}
