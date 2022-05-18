using Lab2GisOpenApiServer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab2GisOpenApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly IAtmRepository _repository;

        public AtmController(IAtmRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Atm> Get()
        {
            return _repository.GetAtms();
        }
    }
}
