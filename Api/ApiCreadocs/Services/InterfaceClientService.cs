using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceClientService
    {
        ClientRetour CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName);
        ClientRetour GetClientByNumId(string numIdCli);
        ClientRetour UpdateClient(Client client, string postalCode, string placeName, string countryCode, string countryName);
    }
}

///Précédente version  de l'interface sans fonction update client

//public interface InterfaceClientService
//{
//    ClientRetour CreateClient(Client client, string postalCode, string placeName, string countryCode, string countryName);

//    //tentative de retour d'objet ClientRetour
//    ClientRetour GetClientByNumId(string numIdCli);
//}