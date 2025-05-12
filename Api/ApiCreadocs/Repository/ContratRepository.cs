using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class ContratRepository : InterfaceContratRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public ContratRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Contrat> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM CONTRAT";
            return connection.Query<Contrat>(requete);
        }
        public ContratAssur GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT id_Contr, CONTRAT.id_TypContr, typContr, id_inter, id_Cli, CONTRAT.id_Assu, nomAssu, valeurAssu, dateContr, dateDebutContr, dateFinContr FROM CONTRAT " +
                "INNER JOIN TYPE_CONTRAT ON CONTRAT.id_typContr = TYPE_CONTRAT.id_typContr " +
                "INNER JOIN ASSURANCE ON CONTRAT.id_Assu = ASSURANCE.id_Assu" +
                " WHERE id_Contr = @id_Contr;";
            return connection.QueryFirstOrDefault<ContratAssur>(requete, new { id_Contr = id });
        }
        //Retour des contrats de l'utilisateur connecté
        public IEnumerable<ContratRetourInter> GetAllById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT id_Contr, nomCli, prenomCli, typContr, dateContr, fichierContr  FROM CONTRAT " +
                "INNER JOIN CLIENTS ON CLIENTS.id_Cli = CONTRAT.id_Cli " +
                "INNER JOIN TYPE_CONTRAT ON CONTRAT.id_typContr = TYPE_CONTRAT.id_typContr " +
                "WHERE id_inter = @id_inter AND fichierContr is not null;";
            return connection.Query<ContratRetourInter>(requete, new { id_inter = id });
        }

        //Incrémentation de la fonctionalité d'ajout de contrat afin qu'elle retourne toutes les informations de CONTRAT ainsi que ASSURANCE.
        public int Add(Contrat contrat)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = @"
        INSERT INTO CONTRAT(id_typContr, numCarte, id_inter, id_Cli, id_Assu, id_mutu, numSim, dateContr, dateDebutContr, dateFinContr) 
        VALUES (@id_typContr, @numCarte, @id_inter, @id_Cli, @id_Assu, @id_mutu, @numSim, @dateContr, @dateDebutContr, @dateFinContr);
        SELECT CAST(SCOPE_IDENTITY() as int)";
            return connection.QueryFirstOrDefault<int>(requete, contrat);
        }

        //SAUVEGARDE CONTRAT

        public bool Update(Contrat updatedContrat)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            {
                connection.Open();
                var query = "UPDATE CONTRAT SET fichierContr = @fichierContr WHERE id_Contr = @id_Contr";
                var result = connection.Execute(query, updatedContrat);
                return result > 0;
            }
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM CONTRAT WHERE id_Contr = @id_Contr";
            connection.Execute(requete, new { id_Contr = id });
        }
    }
}
