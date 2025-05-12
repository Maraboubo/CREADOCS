using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Pays
    {
        [Key]
        public string countryCode { get; set; }
        public string countryName { get; set; }
    }
}
