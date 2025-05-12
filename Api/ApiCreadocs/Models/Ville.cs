using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Ville
    {
        [Key]
        public int id_ville { get; set; }
        public string countryCode { get; set; }
        public string postalCode { get; set; }
        public string placeName { get; set; }
    }
}
