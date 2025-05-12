using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/assurance")]
    [ApiController]
    public class AssuranceController : ControllerBase
    {
        private readonly InterfaceAssuranceService _interfaceAssuranceService;
        public AssuranceController(InterfaceAssuranceService interfaceAssuranceService)
        {
            _interfaceAssuranceService = interfaceAssuranceService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Assurance>> Get()
        {
            var assurances = _interfaceAssuranceService.GetAllAssurances();
            return Ok(assurances);
        }
    }
}
