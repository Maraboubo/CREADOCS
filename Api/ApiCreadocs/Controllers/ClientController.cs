using ApiCreadocs.Models;
using ApiCreadocs.Services;
using ApiCreadocs.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly InterfaceClientService _clientService;

        public ClientController(InterfaceClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public ActionResult<ClientRetour> Post([FromBody] ClientCreationDto clientCreationDto)
        {
            var updatedClient = _clientService.UpdateClient(
                clientCreationDto.Client,
                clientCreationDto.postalCode,
                clientCreationDto.placeName,
                clientCreationDto.countryCode,
                clientCreationDto.countryName);

            return Ok(updatedClient);
        }

        [HttpGet("{numIdCli}")]
        public ActionResult<ClientRetour> Get(string numIdCli)
        {
            var client = _clientService.GetClientByNumId(numIdCli);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}

///Version du controller sans fonction update.

//[ApiController]
//[Route("api/client")]
//public class ClientController : ControllerBase
//{
//    private readonly InterfaceClientService _clientService;

//    public ClientController(InterfaceClientService clientService)
//    {
//        _clientService = clientService;
//    }

//    //Tentative de retourner un objet RetourClient

//    [HttpPost]
//    public ActionResult<ClientRetour> Post([FromBody] ClientCreationDto clientCreationDto)
//    {
//        var createdClient = _clientService.CreateClient(
//            clientCreationDto.Client,
//            clientCreationDto.postalCode,
//            clientCreationDto.placeName,
//            clientCreationDto.countryCode,
//            clientCreationDto.countryName);

//        if (createdClient.numIdCli == clientCreationDto.Client.numIdCli) // Si le client existait déjà
//        {
//            return Ok(createdClient);
//        }

//        return CreatedAtAction(nameof(Get), new { id = createdClient.numIdCli }, createdClient);
//    }

//    //Tentative de retourner un objet ClientRetour

//    [HttpGet("{numIdCli}")]
//    public ActionResult<ClientRetour> Get(string numIdCli)
//    {
//        var client = _clientService.GetClientByNumId(numIdCli);
//        if (client == null)
//        {
//            return NotFound();
//        }
//        return Ok(client);
//    }
//}



///Enciennes versions des methodes GET ET POST

//[HttpPost]
//public ActionResult<Client> Post([FromBody] ClientCreationDto clientCreationDto)
//{
//    var createdClient = _clientService.CreateClient(
//        clientCreationDto.Client,
//        clientCreationDto.postalCode,
//        clientCreationDto.placeName,
//        clientCreationDto.countryCode,
//        clientCreationDto.countryName);

//    if (createdClient.id_Cli != clientCreationDto.Client.id_Cli) // Si le client existait déjà
//    {
//        return Ok(createdClient);
//    }

//    return CreatedAtAction(nameof(Get), new { id = createdClient.id_Cli }, createdClient);
//}

//Création client sans vérification d'existant


//[HttpPost]
//public ActionResult<Client> Post([FromBody] ClientCreationDto clientCreationDto)
//{
//    var createdClient = _clientService.CreateClient(
//        clientCreationDto.Client,
//        clientCreationDto.postalCode,
//        clientCreationDto.placeName,
//        clientCreationDto.countryCode,
//        clientCreationDto.countryName);

//    return CreatedAtAction(nameof(Get), new { id = createdClient.id_Cli }, createdClient);
//}

//[HttpPost]
//public ActionResult<Client> Post([FromBody] Client client, [FromQuery] string postalCode, [FromQuery] string placeName, [FromQuery] string countryCode, [FromQuery] string countryName)
//{
//    var createdClient = _clientService.CreateClient(client, postalCode, placeName, countryCode, countryName);
//    return CreatedAtAction(nameof(Get), new { id = createdClient.id_Cli }, createdClient);
//}

//Premiere methode Get

//[HttpGet("{id}")]
//public ActionResult<Client> Get(int id)
//{
//    // Implémenter la logique pour récupérer le client par ID
//    return Ok(); // Placeholder
//}
