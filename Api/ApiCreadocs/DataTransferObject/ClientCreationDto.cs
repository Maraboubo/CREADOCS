using ApiCreadocs.Models;

namespace ApiCreadocs.DataTransferObject
{
    public class ClientCreationDto
    {
        public Client Client { get; set; }
        public string postalCode { get; set; }
        public string placeName { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
    }
}
