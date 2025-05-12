using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class AssuranceRepository : InterfaceAssuranceRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public AssuranceRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Assurance> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM ASSURANCE";
            return connection.Query<Assurance>(requete);
        }
    }
}
