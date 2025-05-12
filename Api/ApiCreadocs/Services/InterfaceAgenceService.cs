using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceAgenceService
    {
        IEnumerable<Agence> GetAllAgences();
        Agence GetAgenceById(int id);
        void CreateAgence(Agence agence);
        void UpdateAgence(Agence agence);
        void DeleteAgence(int id);
    }
}
