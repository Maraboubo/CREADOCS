using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class AgenceService : InterfaceAgenceService
    {
        private readonly InterfaceAgenceRepository _interfaceAgenceRepository;
        public AgenceService(InterfaceAgenceRepository interfaceAgenceRepository)
        {
            _interfaceAgenceRepository = interfaceAgenceRepository;
        }
        public IEnumerable<Agence> GetAllAgences()
        {
            return _interfaceAgenceRepository.GetAll();
        }
        public Agence GetAgenceById(int id)
        {
            return _interfaceAgenceRepository.GetById(id);
        }

        public void CreateAgence(Agence agence)
        {
            _interfaceAgenceRepository.Add(agence);
        }

        public void UpdateAgence(Agence agence)
        {
            _interfaceAgenceRepository.Update(agence);
        }

        public void DeleteAgence(int id)
        {
            _interfaceAgenceRepository.Delete(id);
        }
    }
}
