using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceAgenceRepository
    {
        IEnumerable<Agence> GetAll();
        Agence GetById(int id);
        void Add(Agence agence);
        void Update(Agence agence);
        void Delete(int id);
    }
}
