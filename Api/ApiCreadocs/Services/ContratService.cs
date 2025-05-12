using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class ContratService : InterfaceContratService
    {
        private readonly InterfaceContratRepository _interfaceContratRepository;
        public ContratService(InterfaceContratRepository interfaceContratRepository)
        {
            _interfaceContratRepository = interfaceContratRepository;
        }
        public IEnumerable<Contrat> GetAllContrats()
        {
            return _interfaceContratRepository.GetAll();
        }
        public ContratAssur GetContratById(int id)
        {
            return _interfaceContratRepository.GetById(id);
        }

        //Retour des Contrats des interlocuteurs connectés.
        public IEnumerable<ContratRetourInter> GetAllContratsInterlocuteur(int id)
        {
            return _interfaceContratRepository.GetAllById(id);
        }

        public int CreateContrat(Contrat contrat)
        {
            return _interfaceContratRepository.Add(contrat);
        }

        //SAUVEGARDE CONTRAT

        public bool UpdateContrat(int id, Contrat updatedContrat)
        {
            var existingContrat = _interfaceContratRepository.GetById(id);
            if (existingContrat == null)
            {
                return false;
            }
            updatedContrat.id_Contr = id;
            return _interfaceContratRepository.Update(updatedContrat);
        }

        public void DeleteContrat(int id)
        {
            _interfaceContratRepository.Delete(id);
        }

    }
}
