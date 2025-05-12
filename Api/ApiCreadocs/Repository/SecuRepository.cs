using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class SecuRepository : InterfaceSecuRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public SecuRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Secu> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM SECURITE_SOCIALE";
            return connection.Query<Secu>(requete);
        }
    }
}
