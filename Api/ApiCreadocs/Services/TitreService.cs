using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class TitreService : InterfaceTitreService
    {
        private readonly InterfaceTitreRepository _interfaceTitreRepository;
        public TitreService(InterfaceTitreRepository interfaceTitreRepository)
        {
            _interfaceTitreRepository = interfaceTitreRepository;
        }
        public IEnumerable<Titre> GetAllTitres()
        {
            return _interfaceTitreRepository.GetAll();
        }
        public Titre GetTitreById(int id)
        {
            return _interfaceTitreRepository.GetById(id);
        }

        public void CreateTitre(Titre titre)
        {
            _interfaceTitreRepository.Add(titre);
        }

        public void UpdateTitre(Titre titre)
        {
            _interfaceTitreRepository.Update(titre);
        }

        public void DeleteTitre(int id)
        {
            _interfaceTitreRepository.Delete(id);
        }
    }
}
