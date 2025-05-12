using Microsoft.Data.SqlClient;
using System.Data;


namespace ApiCreadocs.Repository
{
    public class GenerateurConnexion : InterfaceConnexion
    {
        private readonly string _ligneDeConnexion;
        public GenerateurConnexion(string uneLigneDeConnexion)
        {
            _ligneDeConnexion = uneLigneDeConnexion;
        }
        public IDbConnection CreateConnexion()
        {
            return new SqlConnection(_ligneDeConnexion);
        }
    }
}
