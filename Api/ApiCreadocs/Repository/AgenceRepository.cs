using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class AgenceRepository : InterfaceAgenceRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public AgenceRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Agence> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM AGENCE";
            return connection.Query<Agence>(requete);
        }
        public Agence GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM AGENCE WHERE id_agence = @id_agence";
            return connection.QueryFirstOrDefault<Agence>(requete, new { id_agence = id });
        }
        public void Add(Agence agence)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            //VerificationChampsExistants(agence);
            string requete = "INSERT INTO AGENCE(nomAgence, nomDirAgence, prenomDirAgence)" +
                "VALUES (@nomAgence, @nomDirAgence, @prenomDirAgence)";
            connection.Execute
                (requete, agence);
        }
        public void Update(Agence agence)
        {
            //VerificationDeChamps(agence);

            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "UPDATE AGENCE SET nomAgence = @nomAgence, nomDirAgence = @nomDirAgence, prenomDirAgence = @prenomDirAgence";
            connection.Execute(requete, agence);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM AGENCE WHERE id_agence = @id_agence";
            connection.Execute(requete, new { id_inter = id });
        }

        //public void VerificationDeChamps(Interlocuteur unInterlocuteur)
        //{
        //    // Validation des données de l'utilisateur
        //    if (unInterlocuteur == null)
        //    {
        //        throw new ArgumentNullException(nameof(unInterlocuteur), "L'utilisateur ne peut pas être nul.");
        //    }

        //    if (unInterlocuteur.id_inter <= 0)
        //    {
        //        throw new ArgumentException("L'ID utilisateur doit être supérieur à 0.", nameof(unInterlocuteur.id_inter));
        //    }

        //    if (string.IsNullOrWhiteSpace(unInterlocuteur.nomInter))
        //    {
        //        throw new ArgumentException("Le nom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.nomInter));
        //    }

        //    if (string.IsNullOrWhiteSpace(unInterlocuteur.prenomInter))
        //    {
        //        throw new ArgumentException("Le prénom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.prenomInter));
        //    }

        //    if (string.IsNullOrWhiteSpace(unInterlocuteur.mailInter) || !IsValidEmail(unInterlocuteur.mailInter))
        //    {
        //        throw new ArgumentException("L'adresse email de l'utilisateur est invalide.", nameof(unInterlocuteur.mailInter));
        //    }
        //}

        //public void VerificationChampsExistants(Interlocuteur unInterlocuteur)
        //{
        //    using var connection = _interfaceConnection.CreateConnexion();
        //    string requete = "select count(*) as Count from INTERLOCUTEUR where mailInter = @mailInter";
        //    dynamic result = connection.Query(requete, unInterlocuteur).Single();
        //    int count = result.Count;
        //    if (count > 0)
        //    {
        //        throw new ArgumentException("L'adresse email de l'utilisateur existe déjà.", nameof(unInterlocuteur.mailInter));
        //    }
        //}

        //private bool IsValidEmail(string email)
        //{
        //    //Validation du champ mail
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
