using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceClientRepository
    {
        int AddClient(Client client);
        ClientRetour GetClientByNumId(string numIdCli);
        void UpdateClient(ClientRetour client);
    }
}


///Précédente version de l'interface client Repository sans UpdateClient
//public interface InterfaceClientRepository
//{
//    int AddClient(Client client);
//    ClientRetour GetClientByNumId(string numIdCli);
//}
