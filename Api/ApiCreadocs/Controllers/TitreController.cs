using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/titre")]
    [ApiController]
    public class TitreController : ControllerBase
    {
        private readonly InterfaceTitreService _interfaceTitreService;
        public TitreController(InterfaceTitreService interfaceTitreService)
        {
            _interfaceTitreService = interfaceTitreService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Titre>> Get()
        {
            var titres = _interfaceTitreService.GetAllTitres();
            return Ok(titres);
        }
        [HttpGet("{id}")]
        public ActionResult<Titre> Get(int id)
        {
            var titre = _interfaceTitreService.GetTitreById(id);
            if (titre == null)
            {
                return NotFound();
            }
            return Ok(titre);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Titre titre)
        {
            _interfaceTitreService.CreateTitre(titre);
            return CreatedAtAction(nameof(Get), new { id = titre.id_titre }, titre);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Titre titre)
        {
            if (id != titre.id_titre)
            {
                return BadRequest();
            }
            _interfaceTitreService.UpdateTitre(titre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _interfaceTitreService.DeleteTitre(id);
            return NoContent();
        }
    }
}
