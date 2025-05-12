using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationController : ControllerBase
    {
        private readonly InterfaceIdentificationService _interfaceIdentificationService;
        public IdentificationController(InterfaceIdentificationService interfaceIdentificationService)
        {
            _interfaceIdentificationService = interfaceIdentificationService;
        }
        [HttpGet]
        public ActionResult<Identification> Get()
        {
            var Identifications = _interfaceIdentificationService.GetIdentification();
            return Ok(Identifications);
        }
    }
}
