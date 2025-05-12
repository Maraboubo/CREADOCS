using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class TitreRepository : InterfaceTitreRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public TitreRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Titre> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM TITRE";
            return connection.Query<Titre>(requete);
        }
        public Titre GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM TITRE WHERE id_titre = @id_titre";
            return connection.QueryFirstOrDefault<Titre>(requete, new { id_titre = id });
        }
        public void Add(Titre titre)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            //VerificationChampsExistants(agence);
            string requete = "INSERT INTO TITRE(nomTitre)" +
                "VALUES (@nomTitre)";
            connection.Execute
                (requete, titre);
        }
        public void Update(Titre titre)
        {
            //VerificationDeChamps(agence);

            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "UPDATE TITRE SET nomTitre = @nomTitre";
            connection.Execute(requete, titre);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM TITRE WHERE id_titree = @id_titre";
            connection.Execute(requete, new { id_inter = id });
        }
    }
}
