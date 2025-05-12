using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/sexe")]
    [ApiController]
    public class SexeController : ControllerBase
    {
        private readonly InterfaceSexeService _interfaceSexeService;
        public SexeController(InterfaceSexeService interfaceSexeService)
        {
            _interfaceSexeService = interfaceSexeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Sexe>> Get()
        {
            var sexes = _interfaceSexeService.GetAllSexes();
            return Ok(sexes);
        }
    }
}