using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceTitreService
    {
        IEnumerable<Titre> GetAllTitres();
        Titre GetTitreById(int id);
        void CreateTitre(Titre titre);
        void UpdateTitre(Titre titre);
        void DeleteTitre(int id);
    }
}
