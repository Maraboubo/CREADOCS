using System.ComponentModel.DataAnnotations;

namespace ApiCreadocs.Models
{
    public class Assurance
    {
        [Key]
        public int id_assu { get; set; }
        public string nomAssu { get; set; }
        public int valeurAssu { get; set; }
    }
}
