using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/agence")]
    [ApiController]
    public class AgenceController : ControllerBase
    {
        private readonly InterfaceAgenceService _interfaceAgenceService;
        public AgenceController(InterfaceAgenceService interfaceAgenceService)
        {
            _interfaceAgenceService = interfaceAgenceService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Agence>> Get()
        {
            var agences = _interfaceAgenceService.GetAllAgences();
            return Ok(agences);
        }
        [HttpGet("{id}")]
        public ActionResult<Agence> Get(int id)
        {
            var agence = _interfaceAgenceService.GetAgenceById(id);
            if (agence == null)
            {
                return NotFound();
            }
            return Ok(agence);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Agence agence)
        {
            _interfaceAgenceService.CreateAgence(agence);
            return CreatedAtAction(nameof(Get), new { id = agence.id_agence }, agence);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Agence agence)
        {
            if (id != agence.id_agence)
            {
                return BadRequest();
            }
            _interfaceAgenceService.UpdateAgence(agence);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _interfaceAgenceService.DeleteAgence(id);
            return NoContent();
        }
    }
}
