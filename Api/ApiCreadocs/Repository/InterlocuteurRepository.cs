using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class InterlocuteurRepository : InterfaceInterlocuteurRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public InterlocuteurRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Interlocuteur> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM INTERLOCUTEUR";
            return connection.Query<Interlocuteur>(requete);
        }
        public Interlocuteur GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT id_inter, mailInter, nomInter, prenomInter, telInter, mailInter, INTERLOCUTEUR.id_agence, nomAgence, nomDirAgence, prenomDirAgence, INTERLOCUTEUR.id_titre, nomTitre FROM INTERLOCUTEUR " +
                "INNER JOIN AGENCE ON AGENCE.id_agence = INTERLOCUTEUR.id_agence " +
                "INNER JOIN TITRE ON TITRE.id_titre = INTERLOCUTEUR.id_titre " +
                "WHERE id_inter = @id_inter";
            return connection.QueryFirstOrDefault<Interlocuteur>(requete, new { id_inter = id });
        }

        //Incrémentation de la fonctionalité s'inscription afin qu'elle retourne toutes les informations d'INTERLOCUTEUR ainsi que TITRE et AGENCE.
        public Interlocuteur Add(Interlocuteur interlocuteur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            VerificationChampsExistants(interlocuteur);
            string requete = @"
        INSERT INTO INTERLOCUTEUR(id_titre, id_agence, loginInter, mdpInter, loginKwInter, mdpKwInter, nomInter, prenomInter, telInter, mailInter) 
        VALUES (@id_titre, @id_agence, @loginInter, @mdpInter, @loginKwInter, @mdpKwInter, @nomInter, @prenomInter, @telInter, @mailInter); 
        
        SELECT i.id_Inter, i.prenomInter, i.nomInter, i.telInter, i.mailInter, i.id_titre, i.id_agence,
               a.nomAgence, a.nomDirAgence, a.prenomDirAgence, 
               t.nomTitre 
        FROM INTERLOCUTEUR i
        INNER JOIN AGENCE a ON i.id_agence = a.id_agence
        INNER JOIN TITRE t ON i.id_titre = t.id_titre
        WHERE i.mdpInter = @mdpInter AND i.mailInter = @mailInter;";
            return connection.QueryFirstOrDefault<Interlocuteur>(requete, interlocuteur);
        }

        public void Update(Interlocuteur interlocuteur)
        {
            VerificationDeChamps(interlocuteur);

            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "UPDATE INTERLOCUTEUR SET id_titre = @id_titre, id_agence = @id_agence, " +
                "nomInter = @nomInter, prenomInter = @prenomInter, telInter = @telInter, mailInter = @mailInter WHERE id_inter = @id_inter";
            connection.Execute(requete, interlocuteur);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM INTERLOCUTEUR WHERE id_inter = @id_inter";
            connection.Execute(requete, new { id_inter = id });
        }

        public Interlocuteur GetPass(string email, string password)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            var query = "SELECT id_Inter, prenomInter, nomInter, telInter, INTERLOCUTEUR.id_titre, INTERLOCUTEUR.id_agence, mailInter, nomAgence, nomDirAgence, prenomDirAgence, nomTitre FROM INTERLOCUTEUR" +
                " INNER JOIN AGENCE ON INTERLOCUTEUR.id_agence = AGENCE.id_agence " +
                "INNER JOIN TITRE ON INTERLOCUTEUR.id_titre = TITRE.id_titre WHERE mailInter = @mailInter AND mdpInter = @mdpInter";
            return connection.QueryFirstOrDefault<Interlocuteur>(query, new { mailInter = email, mdpInter = password });
        }

        public void VerificationDeChamps(Interlocuteur unInterlocuteur)
        {
            // Validation des données de l'utilisateur
            if (unInterlocuteur == null)
            {
                throw new ArgumentNullException(nameof(unInterlocuteur), "L'utilisateur ne peut pas être nul.");
            }

            if (unInterlocuteur.id_inter <= 0)
            {
                throw new ArgumentException("L'ID utilisateur doit être supérieur à 0.", nameof(unInterlocuteur.id_inter));
            }

            if (string.IsNullOrWhiteSpace(unInterlocuteur.nomInter))
            {
                throw new ArgumentException("Le nom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.nomInter));
            }

            if (string.IsNullOrWhiteSpace(unInterlocuteur.prenomInter))
            {
                throw new ArgumentException("Le prénom de l'utilisateur ne peut pas être vide.", nameof(unInterlocuteur.prenomInter));
            }

            if (string.IsNullOrWhiteSpace(unInterlocuteur.mailInter) || !IsValidEmail(unInterlocuteur.mailInter))
            {
                throw new ArgumentException("L'adresse email de l'utilisateur est invalide.", nameof(unInterlocuteur.mailInter));
            }
        }

        public void VerificationChampsExistants(Interlocuteur unInterlocuteur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "select count(*) as Count from INTERLOCUTEUR where mailInter = @mailInter";
            dynamic result = connection.Query(requete, unInterlocuteur).Single();
            int count = result.Count;
            if (count > 0)
            {
                throw new ArgumentException("L'adresse email de l'utilisateur existe déjà.", nameof(unInterlocuteur.mailInter));
            }
        }

        private bool IsValidEmail(string email)
        {
            //Validation du champ mail
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
