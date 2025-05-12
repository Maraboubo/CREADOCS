using ApiCreadocs.Models;

namespace ApiCreadocs.Services
{
    public interface InterfaceAssuranceService
    {
        IEnumerable<Assurance> GetAllAssurances();
    }
}
