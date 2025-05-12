using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class SexeService : InterfaceSexeService
    {
        private readonly InterfaceSexeRepository _interfaceSexeRepository;
        public SexeService(InterfaceSexeRepository interfaceSexeRepository)
        {
            _interfaceSexeRepository = interfaceSexeRepository;
        }
        public IEnumerable<Sexe> GetAllSexes()
        {
            return _interfaceSexeRepository.GetAll();
        }
    }
}
