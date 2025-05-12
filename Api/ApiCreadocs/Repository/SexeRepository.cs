using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class SexeRepository : InterfaceSexeRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public SexeRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Sexe>GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM SEXE";
            return connection.Query<Sexe>(requete);
        }
    }
}
