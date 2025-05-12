using ApiCreadocs.Models;
using ApiCreadocs.Repository;
using ApiCreadocs.Services;

namespace ApiCreadocs.Services
{
    public class ClientService : InterfaceClientService
    {
        private readonly InterfaceClientRepository _clientRepository;
        private readonly InterfaceVilleRepository _villeRepository;
        private readonly InterfacePaysRepository _paysRepository;

        public ClientService(InterfaceClientRepository clientRepository, InterfaceVilleRepository villeRepository, InterfacePaysRepository paysRepository)
        {
            _clientRepository = clientRepository;
            _villeRepository = villeRepository;
            _paysRepository = paysRepository;
        }

        public ClientRetour CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName)
        {
            var existingClient = _clientRepository.GetClientByNumId(client.numIdCli);
            if (existingClient != null)
            {
                return existingClient;
            }

            _paysRepository.GetOrCreateCountry(countryCode, countryName);
            int cityId = _villeRepository.GetOrCreateCity(postalCode, placeName, countryCode);
            client.id_ville = cityId;

            int clientId = _clientRepository.AddClient(client);
            client.id_Cli = clientId;

            return _clientRepository.GetClientByNumId(client.numIdCli);
        }

        public ClientRetour GetClientByNumId(string numIdCli)
        {
            return _clientRepository.GetClientByNumId(numIdCli);
        }

        public ClientRetour UpdateClient(Client client, string postalCode, string placeName, string countryCode, string countryName)
        {
            var existingClient = _clientRepository.GetClientByNumId(client.numIdCli);
            if (existingClient == null)
            {
                return CreateClient(client, postalCode, placeName, countryCode, countryName);
            }

            _paysRepository.GetOrCreateCountry(countryCode, countryName);
            int cityId = _villeRepository.GetOrCreateCity(postalCode, placeName, countryCode);
            client.id_ville = cityId;

            existingClient.nomCli = string.IsNullOrEmpty(client.nomCli) ? existingClient.nomCli : client.nomCli;
            existingClient.prenomCli = string.IsNullOrEmpty(client.prenomCli) ? existingClient.prenomCli : client.prenomCli;
            existingClient.telCli = string.IsNullOrEmpty(client.telCli) ? existingClient.telCli : client.telCli;
            existingClient.mailCli = string.IsNullOrEmpty(client.mailCli) ? existingClient.mailCli : client.mailCli;
            existingClient.depNaIssCli = client.depNaIssCli ?? existingClient.depNaIssCli;
            existingClient.dateNaissCli = client.dateNaissCli ?? existingClient.dateNaissCli;
            existingClient.add1Cli = string.IsNullOrEmpty(client.add1Cli) ? existingClient.add1Cli : client.add1Cli;
            existingClient.add2Cli = string.IsNullOrEmpty(client.add2Cli) ? existingClient.add2Cli : client.add2Cli;
            existingClient.add3Cli = string.IsNullOrEmpty(client.add3Cli) ? existingClient.add3Cli : client.add3Cli;
            existingClient.numCompteCli = string.IsNullOrEmpty(client.numCompteCli) ? existingClient.numCompteCli : client.numCompteCli;
            existingClient.numSecuCli = string.IsNullOrEmpty(client.numSecuCli) ? existingClient.numSecuCli : client.numSecuCli;

            existingClient.id_ville = client.id_ville;

            _clientRepository.UpdateClient(existingClient);

            return _clientRepository.GetClientByNumId(client.numIdCli);
        }
    }
}

///Précédente version de ClientService sans mise à jour du client

//public class ClientService : InterfaceClientService
//{
//    private readonly InterfaceClientRepository _clientRepository;
//    private readonly InterfaceVilleRepository _villeRepository;
//    private readonly InterfacePaysRepository _paysRepository;
//    public ClientService(InterfaceClientRepository clientRepository, InterfaceVilleRepository villeRepository, InterfacePaysRepository paysRepository)
//    {
//        _clientRepository = clientRepository;
//        _villeRepository = villeRepository;
//        _paysRepository = paysRepository;
//    }

//    //Tentative de retourner un objet Client Retour

//    public ClientRetour CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName)
//    {
//        var existingClient = _clientRepository.GetClientByNumId(client.numIdCli);
//        if (existingClient != null)
//        {
//            return existingClient;
//        }

//        _paysRepository.GetOrCreateCountry(countryCode, countryName);
//        int cityId = _villeRepository.GetOrCreateCity(postalCode, placeName, countryCode);
//        client.id_ville = cityId;

//        int clientId = _clientRepository.AddClient(client);
//        client.id_Cli = clientId;

//        return _clientRepository.GetClientByNumId(client.numIdCli);
//    }

//    //Tentative de retour d'objet 'ClientRetour'

//    public ClientRetour GetClientByNumId(string numIdCli)
//    {
//        return _clientRepository.GetClientByNumId(numIdCli);
//    }
//}




///Précédentes versions de Service Client

//public Client CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName)
//{
//    var existingClient = _clientRepository.GetClientByNumId(client.numIdCli);
//    if (existingClient != null)
//    {
//        return existingClient;
//    }

//    _paysRepository.GetOrCreateCountry(countryCode, countryName);
//    int cityId = _villeRepository.GetOrCreateCity(postalCode, placeName, countryCode);
//    client.id_ville = cityId;

//    int clientId = _clientRepository.AddClient(client);
//    client.id_Cli = clientId;

//    return client;
//}

//Création de nouveau client sans recherche d'existant.

//public Client CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName)
//{
//    _paysRepository.GetOrCreateCountry(countryCode, countryName);
//    int cityId = _villeRepository.GetOrCreateCity(postalCode, placeName, countryCode);
//    client.id_ville = cityId;

//    int clientId = _clientRepository.AddClient(client);
//    client.id_Cli = clientId;

//    return client;
//}
