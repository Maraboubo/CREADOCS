using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceContratService
    {
        IEnumerable<Contrat> GetAllContrats();
        ContratAssur GetContratById(int id);
        IEnumerable<ContratRetourInter> GetAllContratsInterlocuteur(int id);
        int CreateContrat(Contrat contrat);
        bool UpdateContrat(int id, Contrat contrat);
        void DeleteContrat(int id);
    }
}
