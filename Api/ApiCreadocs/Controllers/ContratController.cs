using ApiCreadocs.DataTransferObject;
using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ApiCreadocs.Controllers
{
    [ApiController]
    [Route("api/contrat")]
    public class ContratController : ControllerBase
    {
        private readonly InterfaceContratService _interfaceContratService;
        public ContratController(InterfaceContratService interfaceContratService)
        {
            _interfaceContratService = interfaceContratService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Contrat>> Get()
        {
            var contrats = _interfaceContratService.GetAllContrats();
            return Ok(contrats);
        }

        //Implémentation contrats par interlocuteur
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ContratRetourInter>> Get(int id)
        {
            var contrats = _interfaceContratService.GetAllContratsInterlocuteur(id);
            return Ok(contrats);
        }

        [HttpPost]
        public ActionResult<ContratAssur> Post([FromBody] Contrat contrat)
        {
            var intCreatedContrat = _interfaceContratService.CreateContrat(contrat);
            var createdContrat = _interfaceContratService.GetContratById(intCreatedContrat);
            if (createdContrat == null)
            {
                return BadRequest("Error creating the contrat.");
            }
            return Ok(createdContrat);
        }

        //SAUVEGARDE CONTRAT

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Contrat contrat)
        {
            if (id != contrat.id_Contr)
            {
                return BadRequest();
            }
            var updatedContrat = _interfaceContratService.UpdateContrat(id, contrat);
            if (!updatedContrat)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _interfaceContratService.DeleteContrat(id);
            return NoContent();
        }
    }
}
