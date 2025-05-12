using ApiCreadocs.Models;

namespace ApiCreadocs.Repository
{
    public interface InterfaceSecuRepository
    {
        IEnumerable<Secu> GetAll();
    }
}