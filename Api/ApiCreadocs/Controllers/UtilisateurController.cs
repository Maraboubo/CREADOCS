using ApiCreadocs.Models;
using ApiCreadocs.Repository;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/utilisateur")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly InterfaceUtilisateurService _interfaceUtilisateurService;
        public UtilisateurController(InterfaceUtilisateurService interfaceUtilisateurService)
        {
            _interfaceUtilisateurService = interfaceUtilisateurService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Utilisateur>> Get()
        {
            var utilisateurs = _interfaceUtilisateurService.GetAllUtilisateurs();
            return Ok(utilisateurs);
        }
        [HttpGet("{id}")]
        public ActionResult<Utilisateur> Get(int id)
        {
            var utilisateur = _interfaceUtilisateurService.GetUtilisateurById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return Ok(utilisateur);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Utilisateur utilisateur)
        {
            _interfaceUtilisateurService.CreateUtilisateur(utilisateur);
            return CreatedAtAction(nameof(Get), new { id = utilisateur.id_Utilisateur }, utilisateur);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Utilisateur utilisateur)
        {
            if (id != utilisateur.id_Utilisateur)
            {
                return BadRequest();
            }
            _interfaceUtilisateurService.UpdateUtilisateur(utilisateur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _interfaceUtilisateurService.DeleteUtilisateur(id);
            return NoContent();
        }
    }
}
