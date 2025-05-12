using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceUtilisateurService
    {
        IEnumerable<Utilisateur> GetAllUtilisateurs();
        Utilisateur GetUtilisateurById(int id);
        void CreateUtilisateur(Utilisateur utilisateur);
        void UpdateUtilisateur(Utilisateur utilisateur);
        void DeleteUtilisateur(int id);
    }
}
