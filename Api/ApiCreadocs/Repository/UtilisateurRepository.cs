using ApiCreadocs.Models;
using Dapper;

namespace ApiCreadocs.Repository
{
    public class UtilisateurRepository : InterfaceUtilisateurRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public UtilisateurRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Utilisateur> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM Utilisateur";
            return connection.Query<Utilisateur>(requete);
        }
        public Utilisateur GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM Utilisateur WHERE id_Utilisateur = @id_Utilisateur";
            return connection.QueryFirstOrDefault<Utilisateur>(requete, new { id_Utilisateur = id });
        }
        public void Add(Utilisateur utilisateur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            VerificationChampsExistants(utilisateur);
            string requete = "INSERT INTO Utilisateur(idStatut, id_vCode, uNom, uPrenom, Email, uIdentifiant, uMotDePasse, Adresse1)" +
                "VALUES (@idStatut, @id_vCode, @uNom, @uPrenom, @Email, @uIdentifiant, @uMotDePasse, @Adresse1)";
            connection.Execute
                (requete, utilisateur);
        }
        public void Update(Utilisateur utilisateur)
        {
            VerificationDeChamps(utilisateur);

            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "UPDATE Utilisateur SET idStatut = @idStatut, id_vCode = @id_vCode, uNom = @uNom, uPrenom = @uPrenom, Email = @Email," +
                "uIdentifiant = @uIdentifiant, uMotDePasse = @uMotDePasse, Adresse1 = @Adresse1 WHERE id_Utilisateur = @id_Utilisateur";
            connection.Execute(requete, utilisateur);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM Utilisateur WHERE id_Utilisateur = @id_Utilisateur";
            connection.Execute(requete, new { id_Utilisateur = id });
        }

        public void VerificationDeChamps(Utilisateur unUtilisateur)
        {
            // Validation des données de l'utilisateur
            if (unUtilisateur == null)
            {
                throw new ArgumentNullException(nameof(unUtilisateur), "L'utilisateur ne peut pas être nul.");
            }

            if (unUtilisateur.id_Utilisateur <= 0)
            {
                throw new ArgumentException("L'ID utilisateur doit être supérieur à 0.", nameof(unUtilisateur.id_Utilisateur));
            }

            if (string.IsNullOrWhiteSpace(unUtilisateur.uNom))
            {
                throw new ArgumentException("Le nom de l'utilisateur ne peut pas être vide.", nameof(unUtilisateur.uNom));
            }

            if (string.IsNullOrWhiteSpace(unUtilisateur.uPrenom))
            {
                throw new ArgumentException("Le prénom de l'utilisateur ne peut pas être vide.", nameof(unUtilisateur.uPrenom));
            }

            if (string.IsNullOrWhiteSpace(unUtilisateur.Email) || !IsValidEmail(unUtilisateur.Email))
            {
                throw new ArgumentException("L'adresse email de l'utilisateur est invalide.", nameof(unUtilisateur.Email));
            }
        }

        public void VerificationChampsExistants(Utilisateur unUtilisateur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "select count(*) as Count from Utilisateur where Email = @Email";
            dynamic result = connection.Query(requete, unUtilisateur).Single();
            int count = result.Count;
            if (count > 0)
            {
                throw new ArgumentException("L'adresse email de l'utilisateur existe déjà.", nameof(unUtilisateur.Email));
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
