using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceTitreRepository
    {
        IEnumerable<Titre> GetAll();
        Titre GetById(int id);
        void Add(Titre titre);
        void Update(Titre titre);
        void Delete(int id);
    }
}
