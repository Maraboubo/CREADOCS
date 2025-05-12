using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class UtilisateurService : InterfaceUtilisateurService
    {
        private readonly InterfaceUtilisateurRepository _intefaceUtilisateurRepository;
        public UtilisateurService(InterfaceUtilisateurRepository interfaceUtilisateurRepository)
        {
            _intefaceUtilisateurRepository = interfaceUtilisateurRepository;
        }
        public IEnumerable<Utilisateur> GetAllUtilisateurs()
        {
            return _intefaceUtilisateurRepository.GetAll();
        }
        public Utilisateur GetUtilisateurById(int id)
        {
            return _intefaceUtilisateurRepository.GetById(id);
        }

        public void CreateUtilisateur(Utilisateur utilisateur)
        {
            _intefaceUtilisateurRepository.Add(utilisateur);
        }

        public void UpdateUtilisateur(Utilisateur utilisateur)
        {
            _intefaceUtilisateurRepository.Update(utilisateur);
        }

        public void DeleteUtilisateur(int id)
        {
            _intefaceUtilisateurRepository.Delete(id);
        }
    }
}
