using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class AssuranceService : InterfaceAssuranceService
    {
        private readonly InterfaceAssuranceRepository _interfaceAssuranceRepository;
        public AssuranceService(InterfaceAssuranceRepository interfaceAssuranceRepository)
        {
            _interfaceAssuranceRepository = interfaceAssuranceRepository;
        }
        public IEnumerable<Assurance> GetAllAssurances()
        {
            return _interfaceAssuranceRepository.GetAll();
        }
    }
}
