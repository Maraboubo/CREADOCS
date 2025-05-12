using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceContratRepository
    {
        IEnumerable<Contrat> GetAll();
        ContratAssur GetById(int id);
        //Retour des contrats de l'utilisateur connecté
        IEnumerable<ContratRetourInter> GetAllById(int id);
        int Add(Contrat contrat);
        bool Update(Contrat contrat);
        void Delete(int id);
    }
}
