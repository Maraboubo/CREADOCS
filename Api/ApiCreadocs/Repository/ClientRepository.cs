using ApiCreadocs.Models;
using ApiCreadocs.Repository;
using Dapper;
using System.Data;
using System.Data.Common;

namespace ApiCreadocs.Repository
{
    public class ClientRepository : InterfaceClientRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;

        public ClientRepository(InterfaceConnexion connection)
        {
            _interfaceConnection = connection;
        }

        public int AddClient(Client client)
        {
            using var connection = _interfaceConnection.CreateConnexion();

            string query = @"INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
                         VALUES (@id_sexe, @id_ville, @id_regimeSecu, @nomCli, @prenomCli, @numIdCli, @telCli, @mailCli, @depNaissCli, @dateNaissCli, @add1Cli, @add2Cli, @add3Cli, @numCompteCli, @numSecuCli);
                         SELECT CAST(SCOPE_IDENTITY() as int)";
            return connection.QueryFirstOrDefault<int>(query, client);
        }

        public ClientRetour GetClientByNumId(string numIdCli)
        {
            using var connection = _interfaceConnection.CreateConnexion();

            string query = "SELECT id_Cli, numIdCli, nomCli, prenomCli, nomSexe, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, CLIENTS.id_ville, VILLES.countryCode, postalCode, placeName, countryName, numCompteCli, numSecuCli, nomRegimeSecu FROM CLIENTS " +
                "INNER JOIN VILLES ON CLIENTS.id_ville = VILLES.id_ville " +
                "INNER JOIN PAYS ON VILLES.countryCode = PAYS.countryCode  " +
                "INNER JOIN SEXE ON CLIENTS.id_sexe = SEXE.id_sexe " +
                "INNER JOIN SECURITE_SOCIALE ON CLIENTS.id_regimeSecu = SECURITE_SOCIALE.id_regimeSecu " +
                "WHERE numIdCli = @NumIdCli";
            return connection.QueryFirstOrDefault<ClientRetour>(query, new { NumIdCli = numIdCli });
        }

        public void UpdateClient(ClientRetour client)
        {
            using var connection = _interfaceConnection.CreateConnexion();

            string query = @"UPDATE CLIENTS SET 
                           nomCli = @nomCli, 
                           prenomCli = @prenomCli, 
                           telCli = @telCli, 
                           mailCli = @mailCli, 
                           depNaIssCli = @depNaIssCli, 
                           dateNaissCli = @dateNaissCli, 
                           add1Cli = @add1Cli, 
                           add2Cli = @add2Cli, 
                           add3Cli = @add3Cli, 
                           numCompteCli = @numCompteCli, 
                           numSecuCli = @numSecuCli,
                           id_ville = @id_ville 
                           WHERE numIdCli = @numIdCli";

            connection.Execute(query, client);
        }
    }
}




///Precedente version de ClientRepository sans UpdateClient

//public class ClientRepository : InterfaceClientRepository
//{
//    private readonly InterfaceConnexion _interfaceConnection;

//    public ClientRepository(InterfaceConnexion connection)
//    {
//        _interfaceConnection = connection;
//    }

//    //Tentative de renvoyer un Objet Client Retour

//    public int AddClient(Client client)
//    {
//        using var connection = _interfaceConnection.CreateConnexion();

//        string query = @"INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
//                         VALUES (@id_sexe, @id_ville, @id_regimeSecu, @nomCli, @prenomCli, @numIdCli, @telCli, @mailCli, @depNaissCli, @dateNaissCli, @add1Cli, @add2Cli, @add3Cli, @numCompteCli, @numSecuCli);
//                         SELECT CAST(SCOPE_IDENTITY() as int)";
//        return connection.QueryFirstOrDefault<int>(query, client);
//    }

//    //Insertion de la vérification de l'existence du client par son numéro d'identification. En objet Client Retour.
//    public ClientRetour GetClientByNumId(string numIdCli)
//    {
//        using var connection = _interfaceConnection.CreateConnexion();

//        string query = "SELECT numIdCli, nomCli, prenomCli, nomSexe, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, postalCode, placeName, countryName, numCompteCli, numSecuCli, nomRegimeSecu FROM CLIENTS " +
//            "INNER JOIN VILLES ON CLIENTS.id_ville = VILLES.id_ville " +
//            "INNER JOIN PAYS ON VILLES.countryCode = PAYS.countryCode  " +
//            "INNER JOIN SEXE ON CLIENTS.id_sexe = SEXE.id_sexe " +
//            "INNER JOIN SECURITE_SOCIALE ON CLIENTS.id_regimeSecu = SECURITE_SOCIALE.id_regimeSecu " +
//            "WHERE numIdCli = @NumIdCli";
//        return connection.QueryFirstOrDefault<ClientRetour>(query, new { NumIdCli = numIdCli });
//    }
//}


///Enciennes methodes Client

//public int AddClient(Client client)
//{
//    using var connection = _interfaceConnection.CreateConnexion();

//    string query = @"INSERT INTO CLIENTS (id_sexe, id_ville, id_regimeSecu, nomCli, prenomCli, numIdCli, telCli, mailCli, depNaIssCli, dateNaissCli, add1Cli, add2Cli, add3Cli, numCompteCli, numSecuCli) 
//                 VALUES (@id_sexe, @id_ville, @id_regimeSecu, @nomCli, @prenomCli, @numIdCli, @telCli, @mailCli, @depNaissCli, @dateNaissCli, @add1Cli, @add2Cli, @add3Cli, @numCompteCli, @numSecuCli);
//                 SELECT CAST(SCOPE_IDENTITY() as int)";
//    return connection.QueryFirstOrDefault<int>(query, client);
//}

////Insertion de la vérification de l'existence du client par son numéro d'identification.
//public Client GetClientByNumId(string numIdCli)
//{
//    using var connection = _interfaceConnection.CreateConnexion();

//    string query = "SELECT * FROM CLIENTS WHERE numIdCli = @NumIdCli";
//    return connection.QueryFirstOrDefault<Client>(query, new { NumIdCli = numIdCli });
//}