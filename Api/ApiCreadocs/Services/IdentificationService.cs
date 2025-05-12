using ApiCreadocs.Models;
using ApiCreadocs.Repository;

namespace ApiCreadocs.Services
{
    public class IdentificationService : InterfaceIdentificationService
    {
        private readonly InterfaceIdentificationRepository _interfaceIdentificationRepository;
        public IdentificationService(InterfaceIdentificationRepository interfaceIdentificationRepository)
        {
            _interfaceIdentificationRepository = interfaceIdentificationRepository;
        }
        public Identification GetIdentification()
        {
            return _interfaceIdentificationRepository.GetIdentif();
        }
    }
}
