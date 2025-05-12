using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class SecuService : InterfaceSecuService
    {
        private readonly InterfaceSecuRepository _interfaceSecuRepository;
        public SecuService(InterfaceSecuRepository interfaceSecuRepository)
        {
            _interfaceSecuRepository = interfaceSecuRepository;
        }
        public IEnumerable<Secu> GetAllSecus()
        {
            return _interfaceSecuRepository.GetAll();
        }
    }
}
