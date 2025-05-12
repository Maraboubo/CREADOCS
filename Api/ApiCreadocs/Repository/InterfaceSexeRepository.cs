using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceSexeRepository
    {
        IEnumerable<Sexe> GetAll();
    }
}