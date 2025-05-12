using Dapper;
using System.Text.RegularExpressions;

namespace ApiCreadocs.Repository
{
    public class StatistiquesRepository : InterfaceStatistiquesRepository 
    {
        private readonly InterfaceConnexion _interfaceConnection;

        public StatistiquesRepository(InterfaceConnexion connection)
        {
            _interfaceConnection = connection;
        }
        //Quelle agence a passé le plus de contrats + nombre de contrats passés
        public (int nbContrat, string nomAgence) GetAgenceMaxContrats()
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT TOP 1 COUNT(id_Contr) AS 'nbContrat', nomAgence FROM CONTRAT " +
                    "INNER JOIN INTERLOCUTEUR ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "INNER JOIN AGENCE ON INTERLOCUTEUR.id_agence = AGENCE.id_agence " +
                    "GROUP BY AGENCE.id_agence, nomAgence " +
                    "ORDER BY nbContrat DESC";

                return connection.QueryFirstOrDefault<(int nbContrat, string nomAgence)>(query);
            }
        }

        //Quel nombre de contrat a passé l'agence de l'interlocuteur
        public (int nbrContratAgence, string nomDagence) GetAgenceNbContrats(int id_agence)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT COUNT(id_Contr) AS 'nbrContratAgence', nomAgence AS 'nomDagence' FROM CONTRAT " +
                    "INNER JOIN INTERLOCUTEUR ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "INNER JOIN AGENCE ON INTERLOCUTEUR.id_agence = AGENCE.id_agence " +
                    "WHERE AGENCE.id_agence = @AgenceId " +
                    "GROUP BY AGENCE.id_agence, nomAgence";

                return connection.QueryFirstOrDefault<(int nbrContratAgence, string nomDagence)> (query, new { AgenceId = id_agence });
            }
        }

        //Quelle est la valeur totale des contrats d'assurance par agence
        public (int valTotaleContatsAssu, string nomDeAgence) GetValContratsAssu(int id_agence)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT SUM(valeurAssu*12) AS'valTotaleContatsAssu', nomAgence as nomDeAgence FROM CONTRAT " +
                    "FULL JOIN ASSURANCE " +
                    "ON ASSURANCE.id_Assu = CONTRAT.id_Assu " +
                    "INNER JOIN INTERLOCUTEUR " +
                    "ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "INNER JOIN AGENCE " +
                    "ON INTERLOCUTEUR.id_agence = AGENCE.id_agence " +
                    "WHERE AGENCE.id_agence = @AgenceId " +
                    "GROUP BY nomAgence";

                return connection.QueryFirstOrDefault<(int valTotaleContatsAssu, string nomDeAgence)>(query, new { AgenceId = id_agence });
            }
        }

        //Quelle quel est le meilleur client de l'agence de l'interlocuteur 
        public (string prenomCli, string nomCli) GetMeilleurClientAgence(int id_agence)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT TOP 1 prenomCli, nomCli, COUNT(CONTRAT.id_Contr) AS 'NOMBRE DE CONTRATS', SUM(valeurAssu*12) AS 'VALEUR TOTALE DES CONTRATS', nomAgence FROM CLIENTS " +
                    "INNER JOIN CONTRAT ON CONTRAT.id_Cli = CLIENTS.id_Cli " +
                    "INNER JOIN ASSURANCE ON ASSURANCE.id_Assu = CONTRAT.id_Assu " +
                    "INNER JOIN INTERLOCUTEUR ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "INNER JOIN AGENCE ON AGENCE.id_agence = INTERLOCUTEUR.id_agence " +
                    "WHERE AGENCE.id_agence = @AgenceId " +
                    "GROUP BY prenomCli, nomCli, nomAgence " +
                    "ORDER BY 'VALEUR TOTALE DES CONTRATS' DESC";

                return connection.QueryFirstOrDefault<(string prenomCli, string nomCli)>(query, new { AgenceId = id_agence});
            }
        }

        //Quel est le type de contrat le plus passé par l'agence de l'interlocuteur
        public (string nomAssu,int nbContrMax) GetMeilleurTypeContrat(int id_agence)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT TOP 1 nomAssu, COUNT(CONTRAT.id_Contr) AS 'nbContrMax', nomAgence FROM ASSURANCE " +
                    "INNER JOIN CONTRAT ON CONTRAT.id_Assu = ASSURANCE.id_Assu " +
                    "INNER JOIN INTERLOCUTEUR ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "INNER JOIN AGENCE ON AGENCE.id_agence = INTERLOCUTEUR.id_agence " +
                    "WHERE AGENCE.id_agence = @AgenceId " +
                    "GROUP BY nomAssu, nomAgence " +
                    "ORDER BY nbContrMax DESC";

                return connection.QueryFirstOrDefault<(string nomAssu, int nbContrMax)>(query, new { AgenceId = id_agence });
            }
        }

        //Combien de contrat a passé l'interlocuteur
        public (int nbContrInter, string nomInter) GetNombreContratInterlocuteur(int id_inter)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT COUNT(id_Contr) AS 'nbContrInter', nomInter FROM CONTRAT " +
                    "INNER JOIN INTERLOCUTEUR " +
                    "ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "WHERE CONTRAT.id_inter = @Identifiant "+
                    "GROUP BY nomInter ";

                return connection.QueryFirstOrDefault<(int nbContrInter,string nomInter )>(query, new { Identifiant = id_inter });
            }
        }

        //Valeur totale des contrats passés par l'interlocuteur
        public (int valTotContrInter, string nomDinter) GetValeurTotaleContratInterlocuteur(int id_inter)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT SUM(valeurAssu*12) AS 'valTotalContrInter', nomInter FROM ASSURANCE " +
                    "INNER JOIN CONTRAT ON ASSURANCE.id_Assu = CONTRAT.id_Assu " +
                    "INNER JOIN INTERLOCUTEUR ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "WHERE CONTRAT.id_inter = @Identifiant " +
                    "GROUP BY nomInter";

                return connection.QueryFirstOrDefault<(int valTotContrInter, string nomInter)>(query, new { Identifiant = id_inter });
            }
        }

        //Quel client a passé le plus de contrat avec l'interlocuteur
        public (string prenomTopCliInter, string nomTopCliInter, int nbContrCliMax) GetMeilleurClientInterlocuteur(int id_inter)
        {

            using var connection = _interfaceConnection.CreateConnexion();
            {
                var query = "SELECT TOP 1 prenomCli, nomCli, COUNT(CONTRAT.id_Contr) AS 'nbContrCliMax'FROM CLIENTS " +
                    "INNER JOIN CONTRAT ON CLIENTS.id_Cli = CONTRAT.id_Cli " +
                    "INNER JOIN INTERLOCUTEUR ON INTERLOCUTEUR.id_inter = CONTRAT.id_inter " +
                    "WHERE CONTRAT.id_inter = @Identifiant " +
                    "GROUP BY prenomCli, nomCli " +
                    "ORDER BY nbContrCliMax DESC";

                return connection.QueryFirstOrDefault<(string prenomCli, string nomCli, int nbContrCliMax)>(query, new { Identifiant = id_inter });
            }
        }
    }
}
