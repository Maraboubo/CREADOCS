using ApiCreadocs.Models;
using ApiCreadocs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/statistiques")]
    [ApiController]
    public class StatistiquesController : ControllerBase
    {
        private readonly InterfaceStatistiquesService _interfaceStatistiquesService;

        public StatistiquesController(InterfaceStatistiquesService interfaceStatistiquesService)
        {
            _interfaceStatistiquesService = interfaceStatistiquesService;
        }
        [HttpPost]
        public ActionResult<Statistiques> GetStatistiques([FromBody] RequeteStatistiques requeteStatistiques)
        {
            var statistiques = _interfaceStatistiquesService.GetStatistiquesInter(requeteStatistiques.id_agence, requeteStatistiques.id_inter);
            return Ok(statistiques);
        }
    }
}
