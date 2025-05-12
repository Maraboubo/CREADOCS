using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/secu")]
    [ApiController]
    public class SecuController : ControllerBase
    {
        private readonly InterfaceSecuService _interfaceSecuService;
        public SecuController(InterfaceSecuService interfaceSecuService)
        {
            _interfaceSecuService = interfaceSecuService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Secu>> Get()
        {
            var secus = _interfaceSecuService.GetAllSecus();
            return Ok(secus);
        }
    }
}