using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceAssuranceRepository
    {
        IEnumerable<Assurance> GetAll();
    }
}
